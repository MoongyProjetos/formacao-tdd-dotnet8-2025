# 🚀 Sessão 8 — Projeto Final + Integração Contínua

## 🎯 Objetivos

* Consolidar todos os conceitos aprendidos sobre **testes, qualidade e automação**.
* Desenvolver um **mini sistema completo** aplicando TDD e boas práticas de integração contínua.
* Discutir **trade-offs do TDD** em contextos reais (projetos grandes, deadlines curtos, times híbridos).
* Apresentar o pipeline completo com **GitHub Actions + SonarCloud** funcionando.

---

## 📚 Material Teórico

### 🧱 O ciclo completo de CI/CD de qualidade

| Etapa                      | Ferramenta           | Descrição                                                 |
| -------------------------- | -------------------- | --------------------------------------------------------- |
| **Testes Unitários e TDD** | xUnit + Moq          | Valida regras de negócio isoladas.                        |
| **Testes de Integração**   | SQLite + Minimal API | Garante o funcionamento real da aplicação.                |
| **CI/CD**                  | GitHub Actions       | Executa build, testes e análise automática a cada commit. |
| **Qualidade e Métricas**   | SonarCloud           | Mede cobertura, duplicação, complexidade e code smells.   |

---

### 💬 TDD na vida real

| Contexto                  | Benefício                               | Cuidado                                   |
| ------------------------- | --------------------------------------- | ----------------------------------------- |
| **Startups**              | Feedback rápido, segurança em refatorar | Custo inicial pode parecer alto           |
| **Projetos Corporativos** | Menos regressões e incidentes           | Requer disciplina no time                 |
| **Sistemas Legados**      | Facilita evolução segura                | Difícil aplicar sem refatorar             |
| **Provas de conceito**    | Força clareza e foco                    | Pode ser overhead se for algo descartável |

> 🧠 *TDD é sobre design, não só sobre teste. Ele faz o código contar sua própria história.*

---

## 🧪 Atividade Prática — Projeto Final

### 🔧 Proposta

Crie uma **API simples de tarefas (To-Do)**, com testes, integração e pipeline configurados.


https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio-code

#### Funcionalidades básicas

| Endpoint                 | Descrição                |
| ------------------------ | ------------------------ |
| `GET /api/tasks`         | Retorna todas as tarefas |
| `POST /api/tasks`        | Cria nova tarefa         |
| `PUT /api/tasks/{id}`    | Atualiza status          |
| `DELETE /api/tasks/{id}` | Remove tarefa            |

#### Regras de negócio

* Não permitir criar tarefa sem título.
* Não permitir duplicar títulos.
* Permitir marcar como concluída.

---

### 🧩 Estrutura sugerida

```
todo-app/
│
├── src/
│   ├── TodoApi/
│   │   ├── Program.cs
│   │   ├── Models/
│   │   │   └── TaskItem.cs
│   │   ├── Data/
│   │   │   └── AppDbContext.cs
│   │   ├── Services/
│   │   │   └── TaskService.cs
│   │   └── Repositories/
│   │       ├── ITaskRepository.cs
│   │       └── TaskRepository.cs
│
├── tests/
│   ├── TodoApi.Tests.Unit/
│   │   └── TaskServiceTests.cs
│   └── TodoApi.Tests.Integration/
│       └── TaskIntegrationTests.cs
│
└── .github/workflows/
    └── ci.yml
```

---

### 🧠 Requisitos do Projeto Final

1. Implementar **testes unitários** com Moq.
2. Criar **testes de integração** com banco em memória (SQLite).
3. Configurar **pipeline GitHub Actions** com build + testes + SonarCloud.
4. Adicionar **badges de Build e Quality Gate** no `README.md`.
5. Corrigir ao menos **1 alerta real** do SonarCloud.
6. Demonstrar a execução completa da pipeline.

---

### 🪶 Exemplo de Badge no README

```markdown
![Build](https://github.com/seu-org/todo-app/actions/workflows/ci.yml/badge.svg)
![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=seu-org_todo-app&metric=alert_status)
```

---

## 💬 Discussão final: trade-offs do TDD

Durante o fechamento, incentive os alunos a refletirem:

* Quando o TDD ajuda (e quando atrapalha)?
* Como equilibrar velocidade e qualidade no dia a dia?
* O que eles fariam diferente num projeto real?

> “O TDD não é sobre escrever testes — é sobre escrever **código melhor**.”

---

## 🧭 Desafio bônus

* Adicione autenticação JWT na API e teste um fluxo completo (login + criação de tarefas).
* Publique o resultado no GitHub público e compartilhe o link com o badge SonarCloud ativo.

---

## ⏱️ Tempo

* **2h30 totais**

  * 20 min — Revisão e setup do projeto final
  * 70 min — Desenvolvimento e testes
  * 30 min — Configuração CI/CD + SonarCloud
  * 30 min — Demonstrações e debate final

---

## 💬 Fechamento

> “CI/CD é o palco onde TDD mostra seu valor.
> O código não mente, os testes não enganam — e a automação é quem aplaude.” 👏

---
Moongy 2025 - Todos os direitos reservados
