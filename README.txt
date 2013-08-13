===============================================================================

SlidePay Windows SDK :: (c)2013 Cube, Co. :: v1.0.0
Written by Joel Christner

For support, email support@getcube.com

===============================================================================

IMPORTANT NOTES:
Do not try to build both projects together.  Build them separately.

The WindowsSDKTest project uses a reference to the DLL that is created by
building the WindowsSDK project.

If you change anything in WindowsSDK, rebuild it by itself (right-click the 
project and select 'Rebuild') to produce an updated DLL.  Then, remove and 
re-add the reference to the DLL in the WindowsSDKTest project's 'Reference'
list.

The DLL output from building the WindowsSDK project can be included in your 
application directly.  Please use the source code and the WindowsSDKTest 
source code as you wish according to the terms and conditions set forth
below.  Use of this software implies acceptance of and agreement with the 
terms and conditions described in the statements below.

The DLL output can be found in the WindowsSDK\bin directory after building.

===============================================================================

RELEASE NOTES:
v1.0.0
- Initial release
- Limited error reporting using the SDK constructor and debug/output window

===============================================================================

VERSION HISTORY:
v1.0.0 - August, 2013
- Initial release

===============================================================================

TERMS AND CONDITIONS:
Copyright (c)2013 Cube, Co.

Permission is hereby granted, free of charge, to any person obtaining a 
copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
sell copies of the Software, and to permit persons to whom the Software is 
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
THE SOFTWARE.

===============================================================================
