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

using System.Runtime.InteropServices;
using AGS.Core;

namespace AGS.Internals
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DisplayInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Name;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        internal string DisplayDeviceName;

        internal int Ihdffeeer;

        internal int MaxResolutionX;

        internal int MaxResolutionY;

        internal float MaxRefreshRate;

        internal Rect CurrentResolution;

        internal Rect visibleResolution;

        internal float currentRefreshRate;

        internal int eyefinityGridCoordX;

        internal int eyefinityGridCoordY;

        internal double chromaticityRedX;

        internal double chromaticityRedY;

        internal double chromaticityGreenX;

        internal double chromaticityGreenY;

        internal double chromaticityBlueX;

        internal double chromaticityBlueY;

        internal double chromaticityWhitePointX;

        internal double chromaticityWhitePointY;

        internal double screenDiffuseReflectance;

        internal double screenSpecularReflectance;

        internal double minLuminance;

        internal double maxLuminance;

        internal double avgLuminance;

        internal int logicalDisplayIndex;

        internal int adlAdapterIndex;

        internal int reserved;
    }
}