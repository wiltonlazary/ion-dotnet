﻿using System;
using System.Collections.Generic;

namespace IonDotnet.Internals
{
    /// <inheritdoc />
    /// <summary>
    /// Provide the functionalities as a buffer for writing Ion data
    /// </summary>
    internal interface IWriteBuffer : IDisposable
    {
        /// <summary>
        /// Write a character sequence into the buffer as UTF8 bytes
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>Number of bytes written</returns>
        /// /// <remarks>Commit to write all the characters, and will throw exception if bad things happen</remarks>
        int WriteUtf8(ReadOnlySpan<char> s);

        /// <summary>
        /// Write a byte.
        /// </summary>
        /// <param name="octet">Octet to write</param>
        void WriteByte(byte octet);

        /// <summary>
        /// Write an 8-bit integer
        /// </summary>
        /// <param name="value">The value to write</param>
        void WriteUint8(long value);

        /// <summary>
        /// Write a 16-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint16(long value);

        /// <summary>
        /// Write a 24-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint24(long value);

        /// <summary>
        /// Write a 32-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint32(long value);

        /// <summary>
        /// Write a 40-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint40(long value);

        /// <summary>
        /// Write a 48-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint48(long value);

        /// <summary>
        /// Write a 56-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint56(long value);

        /// <summary>
        /// Write a 64-bit integer
        /// </summary>
        /// <param name="value">Value to write</param>
        void WriteUint64(long value);

        /// <summary>
        /// Write the whole byte segment into the buffer
        /// </summary>
        /// <param name="bytes">The byte segment</param>
        void WriteBytes(Span<byte> bytes);

        /// <summary>
        /// Write self-delimited int value to the buffer
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <returns>Number of bytes written</returns>
        int WriteVarUint(long value);

        /// <summary>
        /// Start a new write streak
        /// </summary>
        /// <param name="sequence">Supply a list of memory segments to append to once this streak is wrapped up</param>
        void StartStreak(IList<Memory<byte>> sequence);

        /// <summary>
        /// Mark the end of a write streak and add the writen segments in that streak to the sequence
        /// </summary>
        /// <returns>The supplied list after adding all the written segment</returns>
        IList<Memory<byte>> Wrapup();
    }
}
