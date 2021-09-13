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
    /// The ASIC family
    /// </summary>
    public enum AsicFamily
    {
        /// <summary>
        /// Unknown architecture, potentially from another IHV. Check <see cref="DeviceInfo.VendorId"/>
        /// </summary>
        Unknown,

        /// <summary>
        /// Pre GCN architecture
        /// </summary>
        PreGCN,

        /// <summary>
        /// AMD GCN 1 architecture: Oland, Cape Verde, Pitcairn and Tahiti
        /// </summary>
        GCN1,

        /// <summary>
        /// AMD GCN 2 architecture: Hawaii and Bonaire.  This also includes APUs Kaveri and Carrizo
        /// </summary>
        GCN2,

        /// <summary>
        /// AMD GCN 3 architecture: Tonga and Fiji
        /// </summary>
        GCN3,

        /// <summary>
        /// AMD GCN 4 architecture: Polaris
        /// </summary>
        GCN4,

        /// <summary>
        /// AMD Vega architecture, including Raven Ridge (ie AMD Ryzen CPU + AMD Vega GPU)
        /// </summary>
        Vega,

        /// <summary>
        /// AMD RDNA architecture
        /// </summary>
        RDNA,

        /// <summary>
        /// AMD RDNA2 architecture
        /// </summary>
        RDNA2,

        /// <summary>
        /// Number of enumerated ASIC families
        /// </summary>
        Count
    }
}