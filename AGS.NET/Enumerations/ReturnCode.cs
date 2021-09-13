/* Copyright (c) 2021 Kennedy Tochukwu Ekeoha
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace AGS.Enumerations
{
    /// <summary>
    /// The return codes
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// Successful function call
        /// </summary>
        Success,

        /// <summary>
        /// Failed to complete call for some unspecified reason
        /// </summary>
        Failure,

        /// <summary>
        /// Invalid arguments into the function
        /// </summary>
        InvalidArgs,

        /// <summary>
        /// Out of memory when allocating space internally
        /// </summary>    
        OutOfMemory,

        /// <summary>
        /// Returned when a D3D dll fails to load
        /// </summary>      
        MissingD3dDLL,

        /// <summary>
        /// Returned if a feature is not present in the installed driver
        /// </summary>
        LegacyDriver,

        /// <summary>
        /// Returned if the AMD GPU driver does not appear to be installed
        /// </summary>
        NoAmdDriverInstalled,

        /// <summary>
        /// Returned if the driver does not support the requested driver extension
        /// </summary>
        ExtensionNotSupported,

        /// <summary>
        /// Failure in ADL (the AMD Display Library)
        /// </summary>
        AdlFailure,

        /// <summary>
        /// Failure from DirectX runtime
        /// </summary>
        DirectXFailure
    }
}