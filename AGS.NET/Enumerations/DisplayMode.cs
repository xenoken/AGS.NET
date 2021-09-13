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
    /// The display mode
    /// </summary>
    public enum DisplayMode
    {
        /// <summary>
        /// SDR mode
        /// </summary>
        SDR,

        /// <summary>
        /// HDR10 PQ encoding, requiring a 1010102 UNORM swapchain and PQ encoding in the output shade
        /// </summary>
        HDR10_PQ,

        /// <summary>
        /// HDR10 scRGB, requiring an FP16 swapchain. Values of 1.0 == 80 nits, 125.0 == 10000 nits
        /// </summary>
        HDR10_scRGB,

        /// <summary>
        /// Freesync HDR scRGB, requiring an FP16 swapchain. A value of 1.0 == 80 nits
        /// </summary>
        FreesyncHDR_scRGB,

        /// <summary>
        /// Freesync HDR Gamma 2.2, requiring a 1010102 UNORM swapchain.  The output needs to be encoded to gamma 2.2
        /// </summary>
        FreesyncHDR_Gamma22,

        /// <summary>
        /// Dolby Vision, requiring an 8888 UNORM swapchain
        /// </summary>
        DolbyVision,

        /// <summary>
        /// Number of enumerated display modes
        /// </summary>
        Count
    }
}