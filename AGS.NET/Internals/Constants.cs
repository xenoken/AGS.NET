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

namespace AGS.Internals
{
    /// <summary>
    /// Constants holder
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// Name of the DLL to load (64bit)
        /// </summary>
        internal const string DLL_NAME_64 = "amd_ags_x64";

        /// <summary>
        /// Name of the DLL to load (32bit)
        /// </summary>
        internal const string DLL_NAME = "amd_ags_x86";

        /// <summary>
        /// Entry point to the "agsInitialize" native function
        /// </summary>
        internal const string AGS_ENTRY_POINT_INITIALIZE = "agsInitialize";

        /// <summary>
        /// Entry point to the "agsGetVersionNumber" native function
        /// </summary>
        internal const string AGS_ENTRY_POINT_GET_VERSION_NUMBER = "agsGetVersionNumber";

        /// <summary>
        /// Entry point to the "agsDeInitialize" native function
        /// </summary>
        internal const string AGS_ENTRY_POINT_DEINITIALIZE = "agsDeInitialize";

        /// <summary>
        /// Entry point to the "agsSetDisplayMode" native function
        /// </summary>
        internal const string AGS_ENTRY_POINT_SET_DISPLAY_MODE = "agsSetDisplayMode";
    }
}