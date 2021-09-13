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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using AGS.Enumerations;

namespace AGS
{
    /// <summary>
    /// Container for static functions
    /// </summary>
    public static class Statics
    {
        #region MakeVersion

        /// <summary>
        /// AGS Software version
        /// </summary>
        /// <param name="major">Major component</param>
        /// <param name="minor">Minor component</param>
        /// <param name="patch">Patch Component</param>
        /// <returns></returns>
        public static uint MakeVersion(uint major, uint minor, uint patch) {
            return (major << 22) | (minor << 12) | patch;
        }

        public static int GetVersionMajor() {
            return (GetVersionNumber() >> 22) & 0b1111111111;
        }

        public static int GetVersionMinor() {
            return (GetVersionNumber() >> 12) & 0b1111111111;
        }

        public static int GetVersionPatch() {
            return (GetVersionNumber()) & 0b1111111111;
        }

        #endregion

        #region CheckDriverVersion

        /// <summary>
        /// Helper function to check the installed software version against
        /// </summary>
        /// <param name="radeonSoftwareVersionReported">The Radeon Software Version returned from <see cref="GPUInfo.RadeonSoftwareVersion"/></param>
        /// <param name="radeonSoftwareVersionRequired">The Radeon Software Version to check against.  This is specificed using <see cref="MakeVersion(uint, uint, uint)"/></param>
        /// <returns></returns>
        public static DriverVersionResult CheckDriverVersion(string radeonSoftwareVersionReported, uint radeonSoftwareVersionRequired) {
            if (Is64BitProcess()) {
                return AGS.Internals.Statics64.CheckDriverVersion(radeonSoftwareVersionReported, radeonSoftwareVersionRequired);
            }

            return AGS.Internals.Statics.CheckDriverVersion(radeonSoftwareVersionReported, radeonSoftwareVersionRequired);
        }

        #endregion

        #region GetVersionNumber

        /// <summary>
        /// Function to return the AGS version number
        /// </summary>
        /// <returns>The version number made using <see cref="MakeVersion(uint, uint, uint)"/></returns>
        public static int GetVersionNumber() {
            if (Is64BitProcess()) {
                return AGS.Internals.Statics64.GetVersionNumber();
            }

            return AGS.Internals.Statics.GetVersionNumber();
        }

        #endregion

        #region Initialize

        /// <summary>
        /// <para>Function used to initialize the AGS library</para>
        /// Must be called prior to any of the subsequent AGS API calls
        /// </summary>
        /// <param name="gpuInfo">Reference to a GPU Info object that holds relevant information about the graphics card</param>
        /// <returns></returns>
        public static ReturnCode Initialize(out GPUInfo gpuInfo) {
            _contextPtrPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            _gpuInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Internals.GPUInfo)));
            ReturnCode result;

            if (Is64BitProcess()) {
                result = AGS.Internals.Statics64.Initialize(GetVersionNumber(), IntPtr.Zero, _contextPtrPtr, _gpuInfoPtr);
            }
            else {
                result = AGS.Internals.Statics.Initialize(GetVersionNumber(), IntPtr.Zero, _contextPtrPtr, _gpuInfoPtr);
            }

            Internals.GPUInfo info = (Internals.GPUInfo)Marshal.PtrToStructure(_gpuInfoPtr, typeof(Internals.GPUInfo));
            gpuInfo = UnmarshalGPUInfo(info);
            return result;
        }

        #endregion

        #region Deinitialize

        /// <summary>
        /// Function used to clean up the AGS library
        /// </summary>
        /// <returns></returns>
        public static ReturnCode Deinitialize() {
            ReturnCode result = ReturnCode.Failure;
            IntPtr contextPtr = dereferenceContextPtr();

            if (contextPtr != null) {
                if (Is64BitProcess()) {
                    result = AGS.Internals.Statics64.Deinitialize(contextPtr);
                }
                else {
                    result = AGS.Internals.Statics.Deinitialize(contextPtr);
                }
            }

            if (_gpuInfoPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(_gpuInfoPtr);
            }

            if (_contextPtrPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(_contextPtrPtr);
            }

            return result;
        }

        #endregion

        #region SetDisplayMode

        /// <summary>
        /// <para>Function used to set a specific display into HDR mode</para>
        /// <para>Setting all of the values apart from color space and transfer function to zero will cause the display to use defaults</para>
        /// <para>Call this function after each mode change (switch to fullscreen, any change in swapchain etc)</para>
        /// <para>HDR10 PQ mode requires a 1010102 swapchain</para>
        /// <para>HDR10 scRGB mode requires an FP16 swapchain</para>
        /// <para>Freesync HDR scRGB mode requires an FP16 swapchain</para>
        /// <para>Freesync HDR Gamma 2.2 mode requires a 1010102 swapchain</para>
        /// <para>Dolby Vision requires a 8888 UNORM swapchain</para>
        /// </summary>
        /// <param name="context">Pointer to a context. This is generated by <see cref="Initialize(out GPUInfo)"/></param>
        /// <param name="deviceIndex">The index of the device listed in <see cref="GPUInfo.Devices"/></param>
        /// <param name="displayIndex">The index of the display listed in <see cref="DeviceInfo.Displays"/></param>
        /// <param name="managedDisplaySettings">Pointer to the display settings to use</param>
        /// <returns></returns>
        public static ReturnCode SetDisplayMode(int deviceIndex, int displayIndex, DisplaySettings managedDisplaySettings) {
            Internals.DisplaySettings unmanagedDisplaySettings = MarshalDisplaySettings(managedDisplaySettings);

            if (Is64BitProcess()) {
                return AGS.Internals.Statics64.SetDisplayMode(dereferenceContextPtr(), deviceIndex, displayIndex, unmanagedDisplaySettings);
            }

            return AGS.Internals.Statics.SetDisplayMode(dereferenceContextPtr(), deviceIndex, displayIndex, unmanagedDisplaySettings);
        }

        #endregion

        #region Utils

        private static IntPtr dereferenceContextPtr() {
            if (Is64BitProcess()) {
                return new IntPtr(Marshal.ReadInt64(_contextPtrPtr));
            }

            return new IntPtr(Marshal.ReadInt32(_contextPtrPtr));
        }

        private static bool Is64BitProcess() {
            return IntPtr.Size == 8;
        }

        private static GPUInfo UnmarshalGPUInfo(Internals.GPUInfo unmanagedGPUInfo) {
            return new GPUInfo {
                DriverVersion = unmanagedGPUInfo.DriverVersion,
                RadeonSoftwareVersion = unmanagedGPUInfo.RadeonSoftwareVersion,
                Devices = UnmarshalDeviceInfoList(unmanagedGPUInfo),
                NumDevices = unmanagedGPUInfo.NumDevices
            };
        }

        private static ReadOnlyCollection<DeviceInfo> UnmarshalDeviceInfoList(Internals.GPUInfo unmanagedGPUInfo) {
            IntPtr currentDevicePtr = unmanagedGPUInfo.Devices;
            List<DeviceInfo> deviceInfoList = new List<DeviceInfo>();

            for (int deviceIndex = 0; deviceIndex < unmanagedGPUInfo.NumDevices; deviceIndex++) {
                Internals.DeviceInfo unmanagedDeviceInfo = (Internals.DeviceInfo)Marshal.PtrToStructure(currentDevicePtr, typeof(Internals.DeviceInfo));
                deviceInfoList.Add(UnmarshalDeviceInfo(unmanagedDeviceInfo));
                currentDevicePtr = new IntPtr(currentDevicePtr.ToInt64() + Marshal.SizeOf(typeof(Internals.DeviceInfo)));
            }

            return deviceInfoList.AsReadOnly();
        }

        private static DeviceInfo UnmarshalDeviceInfo(Internals.DeviceInfo unmanagedDeviceInfo) {
            return new DeviceInfo {
                AdapterString = unmanagedDeviceInfo.AdapterString,
                AdlAdapterIndex = unmanagedDeviceInfo.AdlAdapterIndex,
                AsicFamily = unmanagedDeviceInfo.AsicFamily,
                CoreClock = unmanagedDeviceInfo.CoreClock,
                DeviceId = unmanagedDeviceInfo.DeviceId,
                Displays = UnmarshalDisplayInfoList(unmanagedDeviceInfo),
                EyefinityBezelCompensated = unmanagedDeviceInfo.EyefinityBezelCompensated > 0,
                EyefinityEnabled = unmanagedDeviceInfo.EyefinityEnabled > 0,
                EyefinityGridHeight = unmanagedDeviceInfo.EyefinityGridHeight,
                EyefinityGridWidth = unmanagedDeviceInfo.EyefinityGridWidth,
                EyefinityResolutionX = unmanagedDeviceInfo.EyefinityResolutionX,
                EyefinityResolutionY = unmanagedDeviceInfo.EyefinityResolutionY,
                IsAPU = (unmanagedDeviceInfo.Iiir & 1) != 0,
                IsExternal = (unmanagedDeviceInfo.Iiir & (1 << 2)) != 0,
                IsPrimaryDevice = (unmanagedDeviceInfo.Iiir & (1 << 1)) != 0,
                LocalMemoryInBytes = unmanagedDeviceInfo.LocalMemoryInBytes,
                MemoryBandwidth = unmanagedDeviceInfo.MemoryBandwidth,
                MemoryClock = unmanagedDeviceInfo.MemoryClock,
                NumCUs = unmanagedDeviceInfo.NumCUs,
                NumDisplays = unmanagedDeviceInfo.NumDisplays,
                NumROPs = unmanagedDeviceInfo.NumROPs,
                NumWGPs = unmanagedDeviceInfo.NumWGPs,
                Reserved = unmanagedDeviceInfo.Reserved,
                RevisionId = unmanagedDeviceInfo.RevisionId,
                SharedMemoryInBytes = unmanagedDeviceInfo.SharedMemoryInBytes,
                TeraFlops = unmanagedDeviceInfo.TeraFlops,
                VendorId = unmanagedDeviceInfo.VendorId
            };
        }

        private static ReadOnlyCollection<DisplayInfo> UnmarshalDisplayInfoList(Internals.DeviceInfo unmanagedDeviceInfo) {
            IntPtr currentDisplayPtr = unmanagedDeviceInfo.Displays;
            List<DisplayInfo> displayInfoList = new List<DisplayInfo>();

            for (int displayIndex = 0; displayIndex < unmanagedDeviceInfo.NumDisplays; displayIndex++) {
                Internals.DisplayInfo unmanagedDisplayInfo = (Internals.DisplayInfo)Marshal.PtrToStructure(currentDisplayPtr, typeof(Internals.DisplayInfo));
                displayInfoList.Add(UnmarshalDisplayInfo(unmanagedDisplayInfo));
                currentDisplayPtr = new IntPtr(currentDisplayPtr.ToInt64() + Marshal.SizeOf(typeof(Internals.DisplayInfo)));
            }

            return displayInfoList.AsReadOnly();
        }

        private static DisplayInfo UnmarshalDisplayInfo(Internals.DisplayInfo unmanagedDisplayInfo) {
            return new DisplayInfo {
                AdlAdapterIndex = unmanagedDisplayInfo.adlAdapterIndex,
                AvgLuminance = unmanagedDisplayInfo.avgLuminance,
                ChromaticityBlueX = unmanagedDisplayInfo.chromaticityBlueX,
                ChromaticityBlueY = unmanagedDisplayInfo.chromaticityBlueY,
                ChromaticityGreenX = unmanagedDisplayInfo.chromaticityGreenX,
                ChromaticityGreenY = unmanagedDisplayInfo.chromaticityGreenY,
                ChromaticityRedX = unmanagedDisplayInfo.chromaticityRedX,
                ChromaticityRedY = unmanagedDisplayInfo.chromaticityRedY,
                ChromaticityWhitePointX = unmanagedDisplayInfo.chromaticityWhitePointX,
                ChromaticityWhitePointY = unmanagedDisplayInfo.chromaticityWhitePointY,
                CurrentRefreshRate = unmanagedDisplayInfo.currentRefreshRate,
                CurrentResolution = unmanagedDisplayInfo.CurrentResolution,
                DisplayDeviceName = unmanagedDisplayInfo.DisplayDeviceName,
                DolbyVision = (unmanagedDisplayInfo.Ihdffeeer & (1 << 2)) != 0,
                FreeSync = (unmanagedDisplayInfo.Ihdffeeer & (1 << 3)) != 0,
                FreeSyncHDR = (unmanagedDisplayInfo.Ihdffeeer & (1 << 4)) != 0,
                EyefinityInGroup = (unmanagedDisplayInfo.Ihdffeeer & (1 << 5)) != 0,
                EyefinityPreferredDisplay = (unmanagedDisplayInfo.Ihdffeeer & (1 << 6)) != 0,
                EyefinityInPortraitMode = (unmanagedDisplayInfo.Ihdffeeer & (1 << 7)) != 0,
                HDR10 = (unmanagedDisplayInfo.Ihdffeeer & (1 << 1)) != 0,
                IsPrimaryDisplay = (unmanagedDisplayInfo.Ihdffeeer & 1) != 0,
                LogicalDisplayIndex = unmanagedDisplayInfo.logicalDisplayIndex,
                MaxLuminance = unmanagedDisplayInfo.maxLuminance,
                MaxRefreshRate = unmanagedDisplayInfo.MaxRefreshRate,
                MaxResolutionX = unmanagedDisplayInfo.MaxResolutionX,
                MaxResolutionY = unmanagedDisplayInfo.MaxResolutionY,
                MinLuminance = unmanagedDisplayInfo.minLuminance,
                Name = unmanagedDisplayInfo.Name,
                Reserved = unmanagedDisplayInfo.reserved,
                ScreenDiffuseReflectance = unmanagedDisplayInfo.screenDiffuseReflectance,
                ScreenSpecularReflectance = unmanagedDisplayInfo.screenSpecularReflectance,
                VisibleResolution = unmanagedDisplayInfo.visibleResolution
            };
        }

        private static Internals.DisplaySettings MarshalDisplaySettings(DisplaySettings managedDisplaySettings) {
            return new Internals.DisplaySettings {
                ChromaticityBlueX = managedDisplaySettings.ChromaticityBlueX,
                ChromaticityBlueY = managedDisplaySettings.ChromaticityBlueY,
                ChromaticityGreenX = managedDisplaySettings.ChromaticityGreenX,
                ChromaticityGreenY = managedDisplaySettings.ChromaticityGreenY,
                ChromaticityRedX = managedDisplaySettings.ChromaticityRedX,
                ChromaticityRedY = managedDisplaySettings.ChromaticityRedY,
                ChromaticityWhitePointX = managedDisplaySettings.ChromaticityWhitePointX,
                ChromaticityWhitePointY = managedDisplaySettings.ChromaticityWhitePointY,
                Dr = (managedDisplaySettings.DisableLocalDimming ? 1U : 0U) << 31
            };
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// Pointer to the Pointer to the Context object in unmanaged memory
        /// </summary>
        private static IntPtr _contextPtrPtr = IntPtr.Zero;

        /// <summary>
        /// Pointer to the GPU Info object in unmanaged memory
        /// </summary>
        private static IntPtr _gpuInfoPtr;

        #endregion
    }
}