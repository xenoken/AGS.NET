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
using System.Collections.ObjectModel;

namespace AGS
{
    /// <summary>
    /// The device info struct used to describe a physical GPU enumerated by AGS
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// The adapter name string
        /// </summary>
        public string AdapterString {get; internal set;}

        /// <summary>
        /// Set to Unknown if not AMD hardware
        /// </summary>
        public AsicFamily AsicFamily {get; internal set;}

        /// <summary>
        /// Whether this device is an APU
        /// </summary>
        public bool IsAPU {get; internal set;}

        /// <summary>
        /// Whether this device is marked as the primary device
        /// </summary>
        public bool IsPrimaryDevice {get; internal set;} 

        /// <summary>
        /// Whether this device is a detachable, external device
        /// </summary>
        public bool IsExternal {get; internal set;}

        /// <summary>
        /// The vendor id
        /// </summary>
        public int VendorId {get; internal set;}

        /// <summary>
        /// The device id
        /// </summary>
        public int DeviceId {get; internal set;}
        
        /// <summary>
        /// The revision id
        /// </summary>
        public int RevisionId {get; internal set;}

        /// <summary>
        /// Number of compute units
        /// </summary>
        public int NumCUs {get; internal set;}

        /// <summary>
        /// Number of RDNA Work Group Processors.  Only valid if ASIC is RDNA onwards
        /// </summary>
        public int NumWGPs {get; internal set;}

        /// <summary>
        /// Number of ROPs
        /// </summary>
        public int NumROPs {get; internal set;}

        /// <summary>
        /// Core clock speed at 100% power in MHz
        /// </summary>
        public int CoreClock {get; internal set;}

        /// <summary>
        /// Memory clock speed at 100% power in MHz
        /// </summary>
        public int MemoryClock {get; internal set;}

        /// <summary>
        /// Memory bandwidth in MB/s
        /// </summary>
        public int MemoryBandwidth {get; internal set;}

        /// <summary>
        /// Teraflops of GPU. Zero if not GCN onwards. Calculated from iCoreClock * iNumCUs * 64 Pixels/clk * 2 instructions/MAD
        /// </summary>
        public float TeraFlops {get; internal set;}

        /// <summary>
        /// The size of local memory in bytes. 0 for non AMD hardware
        /// </summary>
        public ulong LocalMemoryInBytes {get; internal set;}

        /// <summary>
        /// The size of system memory available to the GPU in bytes.  It is important to factor this into your VRAM budget for APUs
        /// as the reported local memory will only be a small fraction of the total memory available to the GPU
        /// </summary>
        public ulong SharedMemoryInBytes {get; internal set;}

        /// <summary>
        /// The number of active displays found to be attached to this adapter
        /// </summary>
        public int NumDisplays {get; internal set;}

        /// <summary>
        /// List of displays allocated by AGS to be numDisplays in length
        /// </summary>
        public ReadOnlyCollection<DisplayInfo> Displays {get; internal set;}

        /// <summary>
        /// Indicates if Eyefinity is active
        /// </summary>
        public bool EyefinityEnabled {get; internal set;}
        
        /// <summary>
        /// Contains width of the multi-monitor grid that makes up the Eyefinity Single Large Surface
        /// </summary>
        public int EyefinityGridWidth {get; internal set;}

        /// <summary>
        /// Contains height of the multi-monitor grid that makes up the Eyefinity Single Large Surface
        /// </summary>
        public int EyefinityGridHeight {get; internal set;}

        /// <summary>
        /// Contains width in pixels of the multi-monitor Single Large Surface
        /// </summary>
        public int EyefinityResolutionX {get; internal set;}

        /// <summary>
        /// Contains height in pixels of the multi-monitor Single Large Surface
        /// </summary>
        public int EyefinityResolutionY {get; internal set;}

        /// <summary>
        /// Indicates if bezel compensation is used for the current SLS display area. 1 if enabled, and 0 if disabled
        /// </summary>
        public bool EyefinityBezelCompensated {get; internal set;}

        /// <summary>
        /// Internally used index into the ADL list of adapters
        /// </summary>
        public int AdlAdapterIndex {get; internal set;}

        /// <summary>
        /// Reserved field
        /// </summary>
        public int Reserved {get; internal set;}     
        
        /// <summary>
        /// Internal Ctor
        /// </summary>
        internal DeviceInfo() {

        }
    }
}