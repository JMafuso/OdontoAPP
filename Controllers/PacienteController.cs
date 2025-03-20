using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly RoboflowService _roboflowService;

    public PacienteController(RoboflowService roboflowService)
    {
        _roboflowService = roboflowService;
    }

    // Endpoint para upload de imagem local
    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile arquivo)
    {
        try
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                return BadRequest(new { mensagem = "Arquivo inválido. Por favor, envie uma imagem." });
            }

            var caminhoTemporario = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(caminhoTemporario))
            {
                await arquivo.CopyToAsync(stream);
            }

            var resultado = await _roboflowService.UploadImageAsync(caminhoTemporario);
            System.IO.File.Delete(caminhoTemporario);

            return Ok(new { mensagem = "Upload concluído com sucesso", resultado });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao fazer upload da imagem", detalhe = ex.Message });
        }
    }

    // Endpoint para inferência de imagem local
    [HttpPost("infer-local")]
    public async Task<IActionResult> InferLocalImage(IFormFile arquivo)
    {
        try
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                return BadRequest(new { mensagem = "Arquivo inválido. Por favor, envie uma imagem." });
            }

            var caminhoTemporario = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(caminhoTemporario))
            {
                await arquivo.CopyToAsync(stream);
            }

            var resultado = await _roboflowService.InferLocalImageAsync(caminhoTemporario);
            System.IO.File.Delete(caminhoTemporario);

            return Ok(new { mensagem = "Inferência concluída com sucesso", resultado });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao realizar inferência da imagem", detalhe = ex.Message });
        }
    }

    // Endpoint para inferência de imagem hospedada
    [HttpPost("infer-hosted")]
    public async Task<IActionResult> InferHostedImage([FromBody] string imageUrl)
    {
        try
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return BadRequest(new { mensagem = "URL da imagem inválida. Por favor, envie uma URL válida." });
            }

            var resultado = await _roboflowService.InferHostedImageAsync(imageUrl);
            return Ok(new { mensagem = "Inferência concluída com sucesso", resultado });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao realizar inferência da imagem hospedada", detalhe = ex.Message });
        }
    }
}
