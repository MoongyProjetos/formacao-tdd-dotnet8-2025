# 📊 Sessão 7 — Análise de Cobertura e Qualidade com SonarCloud

## 🎯 Objetivos

* Entender como o **SonarCloud** avalia a qualidade do código-fonte.
* Configurar o **SonarScanner for .NET** e integrá-lo ao **GitHub Actions**.
* Interpretar métricas de **coverage**, **complexidade**, **duplicação** e **code smells**.
* Resolver um alerta real com base na análise.
* Compreender e aplicar **Quality Gates** e **Pull Request Decoration** no fluxo de CI/CD.

---

## 📚 Material Teórico

### ☁️ O que é o SonarCloud?

O **SonarCloud** é a versão SaaS do SonarQube — hospedada pela SonarSource — e totalmente integrada ao GitHub.
Ele fornece:

* **Code Smells**, **Bugs** e **Vulnerabilidades**
* **Cobertura de testes**
* **Duplicações e complexidade**
* **Quality Gates** que bloqueiam merges com baixa qualidade

---

### ⚙️ Integração com o GitHub

1. Crie uma conta no [SonarCloud](https://sonarcloud.io/) e conecte via **GitHub**.
2. Importe seu repositório (ex: `github-actions-ci`).
3. Obtenha o **Project Key** — algo como `seu-org_github-actions-ci`.
4. Vá em **My Account > Security** e gere um **token** (ex: `SONAR_TOKEN`).
5. No repositório GitHub, adicione os **Secrets**:

   * `SONAR_TOKEN`
   * `SONAR_HOST_URL` → `https://sonarcloud.io`

---

### 🧩 Workflow com SonarCloud

Edite `.github/workflows/ci.yml` para incluir o **SonarCloud Scan**:

```yaml
name: CI

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v4
        with:
          fetch-depth: 0

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 9.0.x

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore --configuration Release

      - name: Test with coverage
        run: dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage

      - name: SonarCloud Scan
        env:
          GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
          SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
        run: |
          dotnet tool install --global dotnet-sonarscanner
          dotnet sonarscanner begin /k:"seu-org_github-actions-ci" /o:"seu-org" /d:sonar.token="${{ secrets.SONAR_TOKEN }}" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.vscoveragexml.reportsPaths=**/coverage.cobertura.xml
          dotnet build --no-incremental
          dotnet sonarscanner end /d:sonar.token="${{ secrets.SONAR_TOKEN }}"
```

> Substitua `seu-org` e `seu-org_github-actions-ci` pelos valores reais da sua conta.

---

### 📊 Interpretação de Métricas

| **Métrica**      | **Descrição**                            | **Ação Recomendada**                  |
| ---------------- | ---------------------------------------- | ------------------------------------- |
| **Coverage**     | Percentual de código coberto por testes. | Aumente a cobertura com novos testes. |
| **Complexity**   | Mede caminhos lógicos.                   | Simplifique métodos grandes.          |
| **Duplications** | Linhas duplicadas.                       | Refatore código repetido.             |
| **Code Smells**  | Más práticas de design.                  | Corrija progressivamente.             |

---

## 🧠 Atividades

1. Executar o pipeline e aguardar o upload para o **SonarCloud**.
2. Abrir o dashboard e interpretar as métricas do projeto.
3. Corrigir ao menos **1 alerta real** (ex: duplicação, variável não usada, método longo).
4. Reexecutar o pipeline e confirmar a melhoria na *Quality Gate*.

---

## 🛡️ Quality Gates e Pull Request Decoration

### 🧩 Quality Gates

Os **Quality Gates** são conjuntos de critérios que definem se o código está "saudável" o suficiente para ser integrado.
Exemplo de critérios padrão do SonarCloud:

* Nenhum **bug** ou **vulnerabilidade crítica**.
* Cobertura mínima de **80%** no novo código.
* Nenhuma duplicação em novas linhas.

Se o projeto **falhar** em algum desses critérios, a *Quality Gate* é marcada como ❌ “Failed” — e isso pode ser usado para **bloquear merges**.

---

### 💬 Pull Request Decoration

Quando o projeto está integrado com o GitHub:

* O SonarCloud **comenta automaticamente** no Pull Request.
* Mostra as métricas do novo código: bugs, code smells, cobertura, duplicações.
* Indica se o PR **passa ou falha** na *Quality Gate*.

🔧 Para ativar:

1. No SonarCloud, vá em **Administration → Analysis Method → GitHub Actions**.
2. Ative **Decorate Pull Requests**.
3. Verifique se o token `GITHUB_TOKEN` tem permissões de leitura/escrita em PRs (padrão).

Assim, cada PR exibirá algo como:

> ✅ Quality Gate Passed — 85% coverage, 0 code smells
> ❌ Quality Gate Failed — 65% coverage (mínimo 80%)

---

### 🪶 Badge de Status no `README.md`

Adicione os badges no `README.md`:

```markdown
![Build](https://github.com/seu-org/github-actions-ci/actions/workflows/ci.yml/badge.svg)
![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=seu-org_github-actions-ci&metric=alert_status)
```

---

## 🧩 Resultado Esperado

Ao final da sessão, o repositório terá:

* CI completo (.NET 9 + Testes + SonarCloud).
* Badges de **Build** e **Quality Gate** no `README.md`.
* Integração de **Pull Request Decoration** no SonarCloud.
* Dashboard público com **Quality Gates ativas**.

---

## 💬 Fechamento

> “Testar é garantir que o código funcione.
> Medir é garantir que ele continue saudável.” 🧠


---

>NOTA:

``` 
R$ 72 milhões. Por hora.

Esse foi o custo da AWS ontem. Só pra Amazon.

Snapchat fora. Venmo travado. Lloyds Bank inacessível. United Airlines atrasando voos. 

Mais de 1.000 empresas impactadas. 

Estimativa de prejuízo: centenas de bilhões de dólares.

A causa? Um erro de DNS no subsistema de monitoramento de load balancers da região US-EAST-1 em Virginia.

Um erro. Uma região. Metade da internet no chão.

E agora vem a pergunta que nenhum board quer ouvir: qual é o seu plano B quando a AWS cai?

Porque se a resposta for "esperar a AWS voltar", você não tem plano B.

Você tem reza.

Ontem, enquanto CTOs do mundo inteiro atualizavam o AWS Status Dashboard obsessivamente, duas verdades inconvenientes emergiram:

𝗩𝗲𝗿𝗱𝗮𝗱𝗲 𝟭: 𝗠𝘂𝗹𝘁𝗶-𝗰𝗹𝗼𝘂𝗱 é 𝗺𝗲𝗻𝘁𝗶𝗿𝗮 𝗽𝗮𝗿𝗮 𝟵𝟬% 𝗱𝗮𝘀 𝗲𝗺𝗽𝗿𝗲𝘀𝗮𝘀

76% das empresas globais rodam aplicações na AWS. 48% dos devs usam serviços AWS.

Você montou aquela arquitetura "cloud-agnostic"? 
Kubernetes pra ter "portabilidade entre clouds"? 
Terraform "pra migrar rápido se precisar"?

Tudo lindo no papel.

Na prática, quando AWS cai, você não faz failover pra GCP em 5 minutos.

Porque seus dados estão em RDS (AWS). 
Suas filas estão em SQS (AWS). 
Seu storage está em S3 (AWS). 
Suas secrets estão em Secrets Manager (AWS). 
Seu DNS está em Route53 (AWS).

"Mas temos DR em outra região!"

US-EAST-1 caiu. Sabe o que mais caiu junto? DynamoDB, SQS, EC2, Amazon Connect, serviços regionais que você jurou que eram resilientes.

Multi-cloud não é ter conta na AWS e GCP.

É ter sistemas ativamente replicados e testados em ambos. Em tempo real. Com custo 2-3x maior.

Quantas empresas realmente fazem isso? Menos de 5%.

O resto tem teatro de resiliência.

𝗩𝗲𝗿𝗱𝗮𝗱𝗲 𝟮: 𝗦𝗟𝗔 𝗻ã𝗼 𝗰𝗼𝗺𝗽𝗲𝗻𝘀𝗮 𝗽𝗿𝗲𝗷𝘂í𝘇𝗼 𝗼𝗽𝗲𝗿𝗮𝗰𝗶𝗼𝗻𝗮𝗹

Especialistas jurídicos alertam: SLAs da AWS oferecem créditos nominais que não cobrem perda de receita ou dano reputacional.

Você paga R$ 300 mil/mês pra AWS. 
Tem SLA de 99.99%. 
AWS cai por 6 horas.

Seu prejuízo: R$ 4 milhões em vendas perdidas + 200 chamados de clientes + reputação arranhada.

Compensação da AWS: ~R$ 9 mil em crédito. 

Parabéns, você foi indenizado em 0.2% do dano.

E ainda tem CTO falando em "confiança no provedor". Confiança sem contingência é negligência com nome bonito.

Não estou dizendo pra abandonar AWS.

AWS atende 90% das Fortune 100. É parte crítica da infraestrutura moderna.

Estou dizendo que se sua arquitetura assume que AWS nunca cai, você está jogando roleta russa com receita.

Porque não é questão de SE vai cair de novo.

AWS já teve grandes interrupções em 2012 (Netflix no Natal), 2021 (temporada de compras) e junho de 2024 (Lambda). Ontem foi só a mais recente.

É questão de QUANDO.

E a pergunta de centenas de bilhões é: Na próxima vez, vocês vão estar atualizando o Status Dashboard... ou executando o playbook que realmente funciona?

Porque entre esses dois cenários, tem uma palavra:

Receita.


````
![alt text](./imagens/amazon.png)