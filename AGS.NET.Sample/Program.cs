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
using System;

namespace AGS.NET.Sample
{
    class Program
    {
        static void Main() {
            if (AGS.Statics.Initialize(out GPUInfo gpuInfo) == ReturnCode.Success) {
                Console.WriteLine("\nAGS Library initialized: v{0}.{1}.{2}\n", AGS.Statics.GetVersionMajor(), AGS.Statics.GetVersionMinor(), AGS.Statics.GetVersionPatch());
                Console.WriteLine("-----------------------------------------------------------------\n");

                Console.WriteLine("Radeon Software Version:   {0}\n", gpuInfo.RadeonSoftwareVersion);
                Console.WriteLine("Driver Version:            {0}\n", gpuInfo.DriverVersion);
                Console.WriteLine("-----------------------------------------------------------------\n");
                PrintDisplayInfo(gpuInfo);
                Console.WriteLine("-----------------------------------------------------------------\n");

                if (AGS.Statics.Deinitialize() != ReturnCode.Success) {
                    Console.WriteLine("Failed to cleanup AGS Library\n");
                }
            }
            else {
                Console.WriteLine("Failed to initialize AGS Library\n");
            }

            Console.WriteLine("\ndone\n");
            Console.ReadLine();
        }

        static string GetVendorName(int vendorId) {
            switch (vendorId) {
                case 0x1002: return "AMD";
                case 0x8086: return "INTEL";
                case 0x10DE: return "NVIDIA";
                default: return "unknown";
            }
        }

        static void PrintDisplayInfo(GPUInfo gpuInfo) {
            for (int gpuIndex = 0; gpuIndex < gpuInfo.NumDevices; gpuIndex++) {
                DeviceInfo device = gpuInfo.Devices[gpuIndex];

                Console.WriteLine("\n---------- Device #{0} {1}, {2}\n", gpuIndex, device.IsPrimaryDevice ? " [primary]" : "", device.AdapterString);

                Console.WriteLine("Vendor id:   {0} ({1})\n", device.VendorId, GetVendorName(device.VendorId));
                Console.WriteLine("Device id:   {0}\n", device.DeviceId);
                Console.WriteLine("Revision id: {0}\n\n", device.RevisionId);

                string[] asicFamilies = { "unknown", "Pre GCN", "GCN Gen1", "GCN Gen2", "GCN Gen3", "GCN Gen4", "Vega", "RDNA", "RDNA2" };

                if (asicFamilies.Length != (int)AsicFamily.Count) {
                    throw new Exception("Asic family table out of date");
                }

                if (device.VendorId == 0x1002) {
                    string wgpInfo = "";

                    if (device.AsicFamily >= AsicFamily.RDNA) {
                        wgpInfo = $", {device.NumWGPs} WGPs";
                    }

                    Console.WriteLine("Architecture: {0}, {1}{2}{3} CUs {4}, {5} ROPs\n", asicFamilies[(int)device.AsicFamily], device.IsAPU ? "(APU), " : "", device.IsExternal ? "(External), " : "", device.NumCUs, wgpInfo, device.NumROPs);
                    Console.WriteLine("    Core clock {0} MHz, Memory clock {1} MHz\n", device.CoreClock, device.MemoryClock);
                    Console.WriteLine("    {0} TFlops\n", device.TeraFlops);
                    Console.WriteLine("Local memory: {0} MBs ({1} GB/s), Shared memory: {2} MBs\n\n", (int)(device.LocalMemoryInBytes / (1024 * 1024)), (float)device.MemoryBandwidth / 1024.0f, (int)(device.SharedMemoryInBytes / (1024 * 1024)));
                }

                Console.WriteLine("\n");

                if (device.EyefinityEnabled) {
                    Console.WriteLine("SLS grid is {0} displays wide by {1} displays tall\n", device.EyefinityGridWidth, device.EyefinityGridHeight);
                    Console.WriteLine("SLS resolution is {0} x {1} pixels {2}\n", device.EyefinityResolutionX, device.EyefinityResolutionY, device.EyefinityBezelCompensated ? ", bezel-compensated" : "");
                }
                else {
                    Console.WriteLine("Eyefinity not enabled on this device\n");
                }

                Console.WriteLine("\n");

                for (int i = 0; i < device.NumDisplays; i++) {
                    DisplayInfo display = device.Displays[i];

                    Console.WriteLine("\t---------- Display {0} {1}----------------------------------------\n", i, display.IsPrimaryDisplay ? "[primary]" : "---------");

                    Console.WriteLine("\tDevice name:   {0}\n", display.DisplayDeviceName);
                    Console.WriteLine("\tMonitor name:  {0}\n\n", display.Name);

                    Console.WriteLine("\tMax resolution:             {0} x {1}, {2} Hz\n", display.MaxResolutionX, display.MaxResolutionY, display.MaxRefreshRate);
                    Console.WriteLine("\tCurrent resolution:         {0} x {1}, Offset ({2}, {3}), {4} Hz\n", display.CurrentResolution.Width, display.CurrentResolution.Height, display.CurrentResolution.OffsetX, display.CurrentResolution.OffsetY, display.CurrentRefreshRate);
                    Console.WriteLine("\tVisible resolution:         {0} x {1}, Offset ({2}, {3})\n\n", display.VisibleResolution.Width, display.VisibleResolution.Height, display.VisibleResolution.OffsetX, display.VisibleResolution.OffsetY);

                    Console.WriteLine("\tChromaticity red:           {0}, {1}\n", display.ChromaticityRedX, display.ChromaticityRedY);
                    Console.WriteLine("\tChromaticity green:         {0}, {1}\n", display.ChromaticityGreenX, display.ChromaticityGreenY);
                    Console.WriteLine("\tChromaticity blue:          {0}, {1}\n", display.ChromaticityBlueX, display.ChromaticityBlueY);
                    Console.WriteLine("\tChromaticity white point:   {0}, {1}\n\n", display.ChromaticityWhitePointX, display.ChromaticityWhitePointY);

                    Console.WriteLine("\tLuminance: [min, max, avg]  {0}, {1}, {2}\n", display.MinLuminance, display.MaxLuminance, display.AvgLuminance);

                    Console.WriteLine("\tScreen reflectance diffuse:  {0}\n", display.ScreenDiffuseReflectance);
                    Console.WriteLine("\tScreen reflectance specular: {0}\n\n", display.ScreenSpecularReflectance);

                    if (display.HDR10)
                        Console.WriteLine("\tHDR10 supported\n");

                    if (display.DolbyVision)
                        Console.WriteLine("\tDolby Vision supported\n");

                    if (display.FreeSync)
                        Console.WriteLine("\tFreesync supported\n");

                    if (display.FreeSyncHDR)
                        Console.WriteLine("\tFreesync HDR supported\n");

                    Console.WriteLine("\n");

                    if (display.EyefinityInGroup) {
                        Console.WriteLine("\tEyefinity Display [{0} mode] {1}\n", display.EyefinityInPortraitMode ? "portrait" : "landscape", display.EyefinityPreferredDisplay ? " (preferred display)" : "");

                        Console.WriteLine("\tGrid coord [{0}, {1}]\n", display.EyefinityGridCoordX, display.EyefinityGridCoordY);
                    }

                    Console.WriteLine("\tLogical display index: {0}\n", display.LogicalDisplayIndex);
                    Console.WriteLine("\tADL adapter index: {0}\n\n", display.AdlAdapterIndex);

                    Console.WriteLine("\n");
                }
            }
        }

        static void TestDriver(string driver, uint driverToCompareAgainst) {
            DriverVersionResult result = AGS.Statics.CheckDriverVersion(driver, driverToCompareAgainst);

            uint major = (driverToCompareAgainst & 0xFFC00000) >> 22;
            uint minor = (driverToCompareAgainst & 0x003FF000) >> 12;
            uint patch = (driverToCompareAgainst & 0x00000FFF);

            if (result == DriverVersionResult.Undefined) {
                Console.WriteLine("Driver check could not determine the driver version for {0}\n", driver);
            }
            else {
                Console.WriteLine("Driver check shows the installed {0} driver is {1} the {2}.{3}.{4} required version\n", driver, result == DriverVersionResult.OK ? "newer or the same as" : "older than", major, minor, patch);
            }
        }
    }
}
