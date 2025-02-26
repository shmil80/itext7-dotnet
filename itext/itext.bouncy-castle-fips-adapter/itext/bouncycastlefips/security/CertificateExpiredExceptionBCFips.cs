using System;
using iText.Commons.Bouncycastle.Security;
using iText.Commons.Utils;
using Org.BouncyCastle.Cert;

namespace iText.Bouncycastlefips.Security {
    /// <summary>Wrapper class for <see cref="ExpiredExceptionBCFips"/>.</summary>
    public class CertificateExpiredExceptionBCFips : AbstractCertificateExpiredException {
        private readonly CertificateExpiredException exception;

        /// <summary>
        /// Creates new wrapper for <see cref="CertificateExpiredException"/>.
        /// </summary>
        /// <param name="exception">
        /// <see cref="CertificateExpiredException"/> to be wrapped
        /// </param>
        public CertificateExpiredExceptionBCFips(CertificateExpiredException exception) {
            this.exception = exception;
        }

        /// <summary>Get actual org.bouncycastle object being wrapped.</summary>
        /// <returns>wrapped <see cref="CertificateExpiredException"/>.</returns>
        public CertificateExpiredException GetException() {
            return exception;
        }
        
        /// <summary>Indicates whether some other object is "equal to" this one.</summary>
        /// <remarks>Indicates whether some other object is "equal to" this one. Compares wrapped objects.</remarks>
        public override bool Equals(Object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            CertificateExpiredExceptionBCFips that = (CertificateExpiredExceptionBCFips)o;
            return Object.Equals(exception, that.exception);
        }

        /// <summary>Returns a hash code value based on the wrapped object.</summary>
        public override int GetHashCode() {
            return JavaUtil.ArraysHashCode(exception);
        }

        /// <summary>
        /// Delegates
        /// <c>toString</c>
        /// method call to the wrapped object.
        /// </summary>
        public override String ToString() {
            return exception.ToString();
        }

        /// <summary>
        /// Delegates
        /// <c>getMessage</c>
        /// method call to the wrapped exception.
        /// </summary>
        public override String Message => exception.Message;
    }
}