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
    /// <summary>
    /// The device info struct used to describe a physical GPU enumerated by AGS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DeviceInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        internal string AdapterString;     

        internal AsicFamily AsicFamily;    

        internal uint Iiir;

        internal int VendorId;             

        internal int DeviceId;             

        internal int RevisionId;           

        internal int NumCUs;               
        
        internal int NumWGPs;              

        internal int NumROPs;              
        
        internal int CoreClock;            
        
        internal int MemoryClock;          
        
        internal int MemoryBandwidth;      
        
        internal float TeraFlops;          

        internal ulong LocalMemoryInBytes; 
        
        internal ulong SharedMemoryInBytes;
                                           
        internal int NumDisplays;              
        
        internal IntPtr Displays;              

        internal int EyefinityEnabled;         
        
        internal int EyefinityGridWidth;       
        
        internal int EyefinityGridHeight;      
        
        internal int EyefinityResolutionX;     
        
        internal int EyefinityResolutionY;     
        
        internal int EyefinityBezelCompensated;

        internal int AdlAdapterIndex;          
        
        internal int Reserved;                 
    }
}