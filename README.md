# OdontoAPP - Sistema de Diagnóstico Odontológico
> Sistema inteligente para diagnóstico odontológico precoce utilizando Machine Learning e Reconhecimento de Imagem

## 📋 Índice

* [Visão Geral do Projeto](#visão-geral-do-projeto)
* [Evolução do Projeto](#evolução-do-projeto)
* [Tecnologias Utilizadas](#tecnologias-utilizadas)
* [Estrutura do Projeto](#estrutura-do-projeto)
* [Reflexão e Autocrítica](#reflexão-e-autocrítica)
* [Planos Futuros](#planos-futuros)

## Visão Geral do Projeto

O OdontoAPP é uma plataforma inovadora que utiliza tecnologias de Machine Learning e Reconhecimento de Imagem para fornecer diagnósticos odontológicos precoces. O sistema permite que pacientes enviem imagens de sintomas bucais e informações sobre seus sintomas, fornecendo recomendações sobre possíveis condições de saúde.

### Principais Funcionalidades
- Upload e análise de imagens de condições bucais
- Processamento de informações sobre sintomas
- Geração de recomendações baseadas em ML
- Interface REST API para integração

## Evolução do Projeto

### Sprint 1 ✅
- Implementação da estrutura básica do projeto
- Desenvolvimento do modelo de dados (Paciente)
- Criação da API REST básica
- Integração com Roboflow para processamento de imagens

### Sprint 4 (Current) 🚀
- Refinamento da API e endpoints
- Implementação completa do CRUD de pacientes
- Integração com serviço de ML (RoboflowService)
- Documentação aprimorada

## Tecnologias Utilizadas

- **Backend**: ASP.NET Core
- **Machine Learning**: 
  - Roboflow para visão computacional
  - TensorFlow/Keras para CNNs
- **Banco de Dados**: Entity Framework Core
- **Documentação**: Swagger/OpenAPI

## Estrutura do Projeto

```
OdontoAPP/
├── Controllers/
│   └── PacienteController.cs
├── Models/
│   └── Paciente.cs
├── Services/
│   └── RoboflowService.cs
├── Repositories/
│   ├── IPacienteRepositorio.cs
│   └── PacienteRepositorio.cs
└── Data/
    └── OdontoDbContext.cs
```

## Reflexão e Autocrítica

### O que funcionou bem 💪
1. **Arquitetura do Projeto**
   - A estrutura em camadas (Controllers, Services, Repositories) proporcionou boa organização
   - Separação clara de responsabilidades
   - Facilidade para manutenção e testes

2. **Integração com ML**
   - Uso eficiente do Roboflow para processamento de imagens
   - Implementação modular permitindo fácil atualização dos modelos

### Desafios Encontrados 🤔
1. **Complexidade do ML**
   - O treinamento inicial do modelo exigiu mais dados do que o previsto
   - Necessidade de ajustes frequentes nos parâmetros do modelo

2. **Integração de Sistemas**
   - Coordenação entre diferentes tecnologias (ASP.NET, Roboflow, DB)
   - Gestão de dependências e versões

### Lições Aprendidas 📚
1. **Planejamento é Crucial**
   - Importância de uma arquitetura bem definida desde o início
   - Necessidade de considerar escalabilidade desde o começo

2. **Documentação Contínua**
   - Manter documentação atualizada facilita o desenvolvimento
   - Comentários e documentação clara são essenciais para manutenção

## Planos Futuros

### Melhorias Técnicas 🛠
1. **Performance**
   - Otimização do processamento de imagens
   - Implementação de cache para resultados frequentes
   - Melhorias na performance do banco de dados

2. **Funcionalidades**
   - Implementação de autenticação e autorização
   - Dashboard para visualização de estatísticas
   - Sistema de notificações para pacientes

### Expansão do Projeto 🚀
1. **Interface do Usuário**
   - Desenvolvimento de uma interface web responsiva
   - Aplicativo mobile para facilitar o envio de imagens

2. **Inteligência Artificial**
   - Expansão do modelo para detectar mais condições
   - Implementação de análise preditiva para prevenção

---

## Equipe
- Jhemysson Moura Vieira (RM552570)
- Robson Apparecido dos Santos (RM552858)
- Talyta Botelho Perrotti (RM553739)

## Licença
Este projeto está sob a licença MIT.
