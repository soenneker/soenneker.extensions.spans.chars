using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Soenneker.Extensions.Spans.Chars;

/// <summary>
/// Various helpful character span extension methods
/// </summary>
public static class SpanCharExtension
{
    /// <summary>
    /// Overwrites the contents of the specified character span with zeros in a manner designed to prevent sensitive
    /// data from lingering in memory.
    /// </summary>
    /// <remarks>This method is intended for use when handling sensitive information, such as passwords or
    /// cryptographic keys, to help reduce the risk of data remaining in memory after it is no longer needed. The
    /// operation is performed in a way that is intended to prevent the compiler or runtime from optimizing away the
    /// memory clearing.</remarks>
    /// <param name="span">The span of characters to be securely cleared. The contents of this span will be overwritten with zeros.</param>
    public static void SecureZero(this Span<char> span)
    {
        CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(span));
    }
}