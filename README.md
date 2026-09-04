# LinkedList

Implementação de uma lista simplesmente encadeada em C#, desenvolvida para fins de estudo de estruturas de dados.

## Estrutura

### Node

Representa um elemento da lista.

- `Data`: valor armazenado no nó, do tipo `string`.
- `Next`: referência para o próximo nó ou `null` quando não há outro elemento.

### LinkedList

Gerencia os nós e mantém as seguintes propriedades:

- `Head`: primeiro nó da lista.
- `Tail`: último nó da lista.
- `Count`: quantidade de elementos armazenados.

Quando a lista está vazia, `Head` e `Tail` possuem valor `null` e `Count` é igual a zero.

## Operações

| Método | Descrição | Complexidade |
| --- | --- | --- |
| `AddAtHead(data)` | Adiciona um elemento no início. | O(1) |
| `AddAtTail(data)` | Adiciona um elemento no final. | O(1) |
| `AddAt(data, index)` | Adiciona um elemento na posição indicada. | O(n) |
| `Get(index)` | Retorna o nó de uma posição. | O(n) |
| `DeleteAtHead()` | Remove o primeiro elemento. | O(1) |
| `DeleteAtTail()` | Remove o último elemento. | O(n) |
| `DeleteAt(index)` | Remove um elemento por índice. | O(n) |
| `foreach` | Percorre a lista na ordem de inserção. | O(n) |

Os índices começam em zero. Em `AddAt`, o valor `Count` também é válido para inserir no final. Índices inválidos geram `IndexOutOfRangeException` nas operações que realizam essa validação.

## Validação de índices

Os métodos que recebem índices utilizam indexação iniciada em zero. Em `AddAt`, os valores de `0` até `Count` são válidos, pois `Count` representa a inserção no final da lista. Em `Get` e `DeleteAt`, os valores válidos vão de `0` até `Count - 1`.

Índices inválidos geram `IndexOutOfRangeException`. Atualmente, a mensagem de erro de `AddAt` informa o limite superior como `Count - 1`, embora o índice `Count` seja aceito para inserção no final.

## Execução

Requisito: .NET 10.

Na raiz da solução, execute:

```bash
dotnet run --project src/LinkedList.App
```

## Testes

Para executar os testes automatizados:

```bash
dotnet test
```

Os testes estão localizados em `tests/LinkedList.App.Tests` e verificam inserções, consultas, remoções e validações de índices.
