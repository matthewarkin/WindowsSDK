===============================================================================

SlidePay Windows SDK :: (c)2013 Cube, Co. :: v1.0.2
Written by Joel Christner

For support, email support@getcube.com

===============================================================================

IMPORTANT NOTES:
The WindowsSDKTest project uses a reference to the output created by
building the WindowsSDK project.  They can now be built together.

The DLL output from building the WindowsSDK project can be included in your 
application directly.  Please use the source code and the WindowsSDKTest 
source code as you wish according to the terms and conditions set forth
below.  Use of this software implies acceptance of and agreement with the 
terms and conditions described in the statements below.

The DLL output can be found in the WindowsSDK\bin directory after building.

===============================================================================

GETTING STARTED:

1) Add reference to WindowsSDK.dll
using WindowsSDK;

2) Instantiate and Authenticate:
Using credentials:
slidepay = new SlidePayWindowsSDK("email", "me@domain.com", "password", true, null);
if (!slidepay.sp_find_endpoint()) exit_application("Could not find an endpoint for email " + email);
if (!slidepay.sp_login()) exit_application("Unable to authenticate");

Using API key:
slidepay = new SlidePayWindowsSDK("api_key", "my_api_key", "https://dev.getcube.com:65532/rest.svc/API/", true, null);
if (!slidepay.sp_token_detail()) exit_application("Could not retrieve token details");

Using token:
slidepay = new SlidePayWindowsSDK("token", "A81Dha381x<truncated_token>", "https://dev.getcube.com:65532/rest.svc/API/", true, null);
if (!slidepay.sp_token_detail()) exit_application("Could not retrieve token details");

3) Process a payment:
processor_cc_txn_response curr = slidepay.sp_key_payment(
  "4111111111111111",  // CCN
  "11",                // expiration month
  "1111",              // expiration year
  "111",               // CVV2
  "11111",             // billing zip
  "Test payment",      // notes
  1.05                 // amount
  );
if (!processor_cc_txn_response.is_approved) Console.WriteLine("Declined");
else Console.WriteLine("Approved payment ID " + curr.payment_id);

===============================================================================

RELEASE NOTES:
v1.0.3 - February, 2014
- Feature updates
- Bugfix to REST client

v1.0.2 - January, 2014
- Feature updates

v1.0.1 - December, 2013
- Feature updates

v1.0.0 - August, 2013
- Initial release
- Limited error reporting using the SDK constructor and debug/output window

===============================================================================

VERSION HISTORY:
v1.0.3 - February, 2014
- Feature updates
- Added support for authorization APIs
- Added support for void API
- Added support for capture API (conversion to automatic capture)
- Added support for capture API (manual capture)

v1.0.2 - January, 2014
- Feature updates
- Added support for authentication via existing token
- Added support for authentication via API key
- Added support for retrieval of token detail

v1.0.1 - December, 2013
- Feature updates
- Added account report and payment report
- Added ACH balance, ACH settlements, ACH retrievals
- Added stored payment support

v1.0.0 - August, 2013
- Initial release
- Payment processing, retrieval, and refunds
- Authentication and endpoint location
- Bank account configuration and management

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
