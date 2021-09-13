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

using AGS.Core;

namespace AGS
{
    /// <summary>
    /// The display info struct used to describe a display enumerated by AGS
    /// </summary>
    public class DisplayInfo
    {
        /// <summary>
        /// The name of the display
        /// </summary>
        public string Name {get; internal set;}

        /// <summary>
        /// The display device name, i.e. DISPLAY_DEVICE::DeviceName
        /// </summary>
        public string DisplayDeviceName {get; internal set;}

        /// <summary>
        /// Whether this display is marked as the primary display
        /// </summary>
        public bool IsPrimaryDisplay {get; internal set;}

        /// <summary>
        /// HDR10 is supported on this display
        /// </summary>
        public bool HDR10 {get; internal set;}

        /// <summary>
        /// Dolby Vision is supported on this display
        /// </summary>
        public bool DolbyVision {get; internal set;}

        /// <summary>
        /// Freesync is supported on this display
        /// </summary>
        public bool FreeSync {get; internal set;}

        /// <summary>
        /// Freesync HDR is supported on this display
        /// </summary>
        public bool FreeSyncHDR {get; internal set;}

        /// <summary>
        /// The display is part of the Eyefinity group
        /// </summary>
        public bool EyefinityInGroup {get; internal set;}

        /// <summary>
        /// The display is the preferred display in the Eyefinity group for displaying the UI
        /// </summary>
        public bool EyefinityPreferredDisplay {get; internal set;}

        /// <summary>
        /// The display is in the Eyefinity group but in portrait mode
        /// </summary>
        public bool EyefinityInPortraitMode {get; internal set;}

        /// <summary>
        /// The maximum supported resolution of the unrotated display
        /// </summary>
        public int MaxResolutionX {get; internal set;}

        /// <summary>
        /// The maximum supported resolution of the unrotated display
        /// </summary>
        public int MaxResolutionY {get; internal set;}

        /// <summary>
        /// The maximum supported refresh rate of the display
        /// </summary>
        public float MaxRefreshRate {get; internal set;}

        /// <summary>
        /// The current resolution and position in the desktop, ignoring Eyefinity bezel compensation
        /// </summary>
        public Rect CurrentResolution {get; internal set;}

        /// <summary>
        /// The visible resolution and position. When Eyefinity bezel compensation is enabled this will
        /// be the sub region in the Eyefinity single large surface (SLS)
        /// </summary>
        public Rect VisibleResolution {get; internal set;}

        /// <summary>
        /// The current refresh rate
        /// </summary>
        public float CurrentRefreshRate {get; internal set;}

        /// <summary>
        /// The X coordinate in the Eyefinity grid. -1 if not in an Eyefinity group
        /// </summary>
        public int EyefinityGridCoordX {get; internal set;}

        /// <summary>
        /// The Y coordinate in the Eyefinity grid. -1 if not in an Eyefinity group
        /// </summary>
        public int EyefinityGridCoordY {get; internal set;}

        /// <summary>
        /// Red display primary X coord
        /// </summary>
        public double ChromaticityRedX {get; internal set;}

        /// <summary>
        /// Red display primary Y coord
        /// </summary>
        public double ChromaticityRedY {get; internal set;}

        /// <summary>
        /// Green display primary X coord
        /// </summary>
        public double ChromaticityGreenX {get; internal set;}

        /// <summary>
        /// Green display primary Y coord
        /// </summary>
        public double ChromaticityGreenY {get; internal set;}

        /// <summary>
        /// Blue display primary X coord
        /// </summary>
        public double ChromaticityBlueX {get; internal set;}

        /// <summary>
        /// Blue display primary Y coord
        /// </summary>
        public double ChromaticityBlueY {get; internal set;}

        /// <summary>
        /// White point X coord
        /// </summary>
        public double ChromaticityWhitePointX {get; internal set;}

        /// <summary>
        ///White point Y coord
        /// </summary>
        public double ChromaticityWhitePointY {get; internal set;}

        /// <summary>
        /// Percentage expressed between 0 - 1
        /// </summary>
        public double ScreenDiffuseReflectance {get; internal set;}

        /// <summary>
        /// Percentage expressed between 0 - 1
        /// </summary>
        public double ScreenSpecularReflectance {get; internal set;}

        /// <summary>
        /// The minimum luminance of the display in nits
        /// </summary>
        public double MinLuminance {get; internal set;}

        /// <summary>
        /// The maximum luminance of the display in nits
        /// </summary>
        public double MaxLuminance {get; internal set;}

        /// <summary>
        /// The average luminance of the display in nits
        /// </summary>
        public double AvgLuminance {get; internal set;}

        /// <summary>
        /// The internally used index of this display
        /// </summary>
        public int LogicalDisplayIndex {get; internal set;}

        /// <summary>
        /// The internally used ADL adapter index
        /// </summary>
        public int AdlAdapterIndex {get; internal set;}

        /// <summary>
        /// Reserved field
        /// </summary>
        public int Reserved {get; internal set;}      
        
        /// <summary>
        /// Internal Ctor
        /// </summary>
        internal DisplayInfo() {

        }
    }
}