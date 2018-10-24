// Copyright (c) 2018 Javier Cañon 
// https://www.javiercanon.com 
// https://www.xn--javiercaon-09a.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagame.Models.Security.Recaptcha
{
    /// <summary>
    /// Represents the result value of recaptcha verification process.
    /// </summary>
    public enum RecaptchaVerificationResult
    {

        #region Common values for v1 and v2

        /// <summary>
        /// Verification failed but the exact reason is not known.
        /// </summary>
        UnknownError = 0,
        /// <summary>
        /// Verification succeeded with no errors.
        /// </summary>
        Success = 1,
        /// <summary>
        /// The user's response to recaptcha challenge is incorrect.
        /// </summary>
        IncorrectCaptchaSolution = 2,
        /// <summary>
        /// The private supplied at the time of verification process is invalid. Private key is also known as secret key in reCAPTCHA v2.
        /// </summary>
        InvalidPrivateKey = 4,
        /// <summary>
        /// The user's response to the recaptcha challenge is null or empty.
        /// </summary>
        NullOrEmptyCaptchaSolution = 5,
        /// <summary>
        /// The private key is missing. Private key is also known as secret key in reCAPTCHA v2.
        /// </summary>
        NullOrEmptyPrivateKey = 7,

        #endregion Common values for v1 and v2

        #region Values for reCAPTCHA v1

        /// <summary>
        /// The request parameters in the client-side cookie are invalid.
        /// </summary>
        InvalidCookieParameters = 3,
        /// <summary>
        /// The recaptcha challenge could not be retrieved.
        /// </summary>
        ChallengeNotProvided = 6

        #endregion Values for reCAPTCHA v1


    }
}
