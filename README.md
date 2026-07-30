# 📄 Documentos Brasileiros API

API REST para validação de documentos brasileiros oficiais, desenvolvida em .NET 10 com Clean Architecture.

## ✅ Documentos Suportados

| Documento | Descrição |
|-----------|-----------|
| CPF | Cadastro de Pessoa Física |
| CNPJ | Cadastro Nacional de Pessoa Jurídica |
| CNH | Carteira Nacional de Habilitação |
| PIS | Programa de Integração Social |
| NIS | Número de Identificação Social |
| CEI | Cadastro Específico do INSS |

## 🚀 Como Usar

### Base URL
### Endpoints

#### POST /api/documento/validar
Valida um documento brasileiro.

**Request:**
```json
{
  "valor": "111.444.777-35",
  "tipo": "CPF"
}
```

**Response (válido):**
```json
{
  "valido": true,
  "documento": "111.444.777-35",
  "tipo": "CPF",
  "erros": [],
  "validadoEm": "2026-07-30T10:00:00Z"
}
```

**Response (inválido):**
```json
{
  "valido": false,
  "documento": "111.111.111-11",
  "tipo": "CPF",
  "erros": ["CPF não pode conter todos os dígitos iguais."],
  "validadoEm": "2026-07-30T10:00:00Z"
}
```

#### GET /api/documento/tipos
Retorna os tipos de documentos suportados.

**Response:**
```json
{
  "tiposSuportados": ["CPF", "CNPJ", "CNH", "PIS", "NIS", "CEI"]
}
```

## 💰 Planos — RapidAPI

Disponível no RapidAPI com planos:

| Plano | Preço | Requests |
|-------|-------|----------|
| Básico | Grátis | 100/mês |
| Pró | $9/mês | 5.000/mês |
| Ultra | $29/mês | 20.000/mês |

👉 [Acessar no RapidAPI](https://rapidapi.com/batistawelinton54/api/documentos-brasileiros)

## 🏗️ Tecnologias

- .NET 10
- Clean Architecture
- Scalar (documentação)
- Docker
- Fly.io

## 📁 Estrutura do Projeto

## 🧪 Exemplos por Documento

### CPF
```json
{ "valor": "111.444.777-35", "tipo": "CPF" }
```

### CNPJ
```json
{ "valor": "11.222.333/0001-81", "tipo": "CNPJ" }
```

### CNH
```json
{ "valor": "12345678900", "tipo": "CNH" }
```

### PIS
```json
{ "valor": "12970563100", "tipo": "PIS" }
```

### NIS
```json
{ "valor": "17033259504", "tipo": "NIS" }
```

### CEI
```json
{ "valor": "110082792940", "tipo": "CEI" }
```

## 📜 Licença

MIT License — sinta-se livre para usar e contribuir!

---

Desenvolvido por [Welinton Batista](https://github.com/welinton19) 🇧🇷
