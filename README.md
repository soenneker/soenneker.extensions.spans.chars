[![](https://img.shields.io/nuget/v/soenneker.extensions.spans.chars.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.spans.chars/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.spans.chars/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.spans.chars/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.spans.chars.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.spans.chars/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.spans.chars/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.spans.chars/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Spans.Chars
Allocation-free helpers for clearing character buffers and writing pre-sized `long` values.

## Installation

```bash
dotnet add package Soenneker.Extensions.Spans.Chars
```

## Clear sensitive characters

```csharp
using Soenneker.Extensions.Spans.Chars;

Span<char> password = stackalloc char[64];
// Fill and use password...
password.SecureZero();
```

`SecureZero()` clears the bytes backing the entire span through `CryptographicOperations.ZeroMemory`, so the write cannot be optimized away. It mutates only the supplied span; copies of the secret remain the caller's responsibility.

## Write an integer into a prepared buffer

```csharp
using Soenneker.Extensions.Spans.Chars;

const long value = -12345;
Span<char> buffer = stackalloc char[6];

buffer.WriteInt64(value, digits: 6);
string text = new(buffer); // "-12345"
```

`WriteInt64()` and `WritePositiveInt64()` are low-level formatting helpers for code that already knows the exact output length. They avoid allocations, but intentionally do not calculate or validate `digits`.

- `WriteInt64()` accepts the full `long` range. `digits` includes the minus sign.
- `WritePositiveInt64()` requires a non-negative value. `digits` is the number of decimal digits.
- The destination must contain at least `digits` characters.
- An incorrect digit count can leave characters unwritten or cause indexing to fail. Use `long.TryFormat()` when the output length is not already known.
