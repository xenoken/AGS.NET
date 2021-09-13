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

using AGS.Enumerations;

namespace AGS
{
    /// <summary>
    /// The struct to specify the display settings to the driver
    /// </summary>
    public class DisplaySettings
    {
        /// <summary>
        /// The display mode to set the display into
        /// </summary>
        public DisplayMode Mode {get; internal set;}

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
        /// White point Y coord
        /// </summary>
        public double ChromaticityWhitePointY {get; internal set;}

        /// <summary>
        /// The minimum scene luminance in nits
        /// </summary>
        public double MinLuminance {get; internal set;}

        /// <summary>
        /// The maximum scene luminance in nits
        /// </summary>
        public double MaxLuminance {get; internal set;}

        /// <summary>
        /// The maximum content light level in nits (MaxCLL)
        /// </summary>
        public double MaxContentLightLevel {get; internal set;}

        /// <summary>
        /// The maximum frame average light level in nits (MaxFALL)
        /// </summary>
        public double MaxFrameAverageLightLevel {get; internal set;}

        /// <summary>
        /// Disables local dimming if possible
        /// </summary>
        public bool DisableLocalDimming {get; internal set;}        
    }
}