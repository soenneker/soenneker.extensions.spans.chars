[![](https://img.shields.io/nuget/v/soenneker.extensions.spans.chars.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.spans.chars/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.spans.chars/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.spans.chars/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.spans.chars.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.spans.chars/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.spans.chars/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.spans.chars/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Spans.Chars
Various helpful character span extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.Spans.Chars
```

## Quick start

```csharp
using Soenneker.Extensions.Spans.Chars;

// Given an existing Span<char> named span:
span.SecureZero();
```

## Common operations

- `SecureZero()` - Overwrites the contents of the specified character span with zeros in a manner designed to prevent sensitive data from lingering in memory.
- `WriteInt64()` - Writes the decimal representation of the specified `long` value into the provided `SpanChar`. This method does not perform bounds checking or validation for performance reasons.
- `WritePositiveInt64()` - Writes the decimal representation of a non-negative `long` value into the provided `SpanChar`. Digits are written in reverse order into the destination span, avoiding allocations and formatting overhead.
