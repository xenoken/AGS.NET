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

using System.Collections.ObjectModel;

namespace AGS
{
    /// <summary>
    /// The top level GPU information returned from <see cref="Statics.Initialize(out GPUInfo)"/>
    /// </summary>
    public class GPUInfo
    {
        /// <summary>
        /// The AMD driver package version
        /// </summary>
        public string DriverVersion { get; internal set; }

        /// <summary>
        /// The Radeon Software Version
        /// </summary>
        public string RadeonSoftwareVersion { get; internal set; }

        /// <summary>
        /// List of GPUs in the system
        /// </summary>
        public ReadOnlyCollection<DeviceInfo> Devices { get; internal set; }

        /// <summary>
        /// Number of GPUs in the system
        /// </summary>
        public int NumDevices { get; internal set; }

        /// <summary>
        /// Internal ctor
        /// </summary>
        internal GPUInfo() {

        }
    }
}