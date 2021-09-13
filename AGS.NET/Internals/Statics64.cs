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

using System;
using System.Runtime.InteropServices;
using AGS.Enumerations;

namespace AGS.Internals
{
    internal static class Statics64
    {
        [DllImport(Constants.DLL_NAME_64)]
        public static extern DriverVersionResult CheckDriverVersion([MarshalAs(UnmanagedType.LPStr)] string radeonSoftwareVersionReported, uint radeonSoftwareVersionRequired);
       
        [DllImport(Constants.DLL_NAME_64, EntryPoint = Constants.AGS_ENTRY_POINT_GET_VERSION_NUMBER)]
        public static extern int GetVersionNumber();

        [DllImport(Constants.DLL_NAME_64, EntryPoint = Constants.AGS_ENTRY_POINT_INITIALIZE)]
        public static extern ReturnCode Initialize(int agsVersion, IntPtr config, IntPtr context, IntPtr gpuInfo);

        [DllImport(Constants.DLL_NAME_64, EntryPoint = Constants.AGS_ENTRY_POINT_DEINITIALIZE)]
        public static extern ReturnCode Deinitialize(IntPtr context);

        [DllImport(Constants.DLL_NAME_64, EntryPoint = Constants.AGS_ENTRY_POINT_SET_DISPLAY_MODE)]
        public static extern ReturnCode SetDisplayMode(IntPtr context, int deviceIndex, int displayIndex, DisplaySettings settings);
    }
}