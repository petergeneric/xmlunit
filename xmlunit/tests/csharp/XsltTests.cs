namespace XmlUnit.Tests {
    using NUnit.Framework;
    using XmlUnit;
    
    [TestFixture]
    public class XsltTests {
        public static readonly string XML_DECLARATION =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            
        public static readonly string XSLT_START =
            "<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\">";
    
        public static readonly string XSLT_TEXT_OUTPUT_NOINDENT =
            "<xsl:output method=\"xml\" encoding=\"UTF-8\" omit-xml-declaration=\"yes\" indent=\"no\"/>";
    
        public static readonly string XSLT_IDENTITY_TEMPLATE =
            "<xsl:template match=\"/\"><xsl:copy-of select=\".\"/></xsl:template>";
    
        public static readonly string XSLT_END = "</xsl:stylesheet>";
        
        [Test] public void CanPerformTransform() {
            string identityTransform = XML_DECLARATION
                + XSLT_START + XSLT_TEXT_OUTPUT_NOINDENT
                + XSLT_IDENTITY_TEMPLATE
                + XSLT_END;
            Xslt xslt = new Xslt(identityTransform);
            string input = "<qwerty>uiop</qwerty>";
            string output = new string(input.ToCharArray());
            Assertion.AssertEquals(output, xslt.Transform(input).AsString());
            Assertion.AssertEquals(output, xslt.Transform(input).AsString());
        }
    }
}
