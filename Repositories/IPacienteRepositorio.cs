﻿using OdontoAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdontoAPP.Repositories
{
    public interface IPacienteRepositorio
    {
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente> ObterPorIdAsync(int id);
        Task AdicionarAsync(Paciente paciente);
        Task AtualizarAsync(Paciente paciente);
        Task RemoverAsync(int id);
    }
}
