namespace OfxNet.Investments;

internal static class OfxInvestmentHelpers
{
    /// <summary>
    /// Helper method for getting an optional OfxCurrency for an investment element.
    /// </summary>
    /// <param name="parent">The element being processed.</param>
    /// <param name="subElementName">The name of the optional OfxCurrency child element.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.</param>
    /// <returns>The <see cref="OfxCurrency"/> or null if the child element is not present.</returns>
    public static OfxCurrency? GetOptionalCurrencySubElement(IOfxElement parent, string subElementName, OfxDocumentSettings settings)
    {
        OfxCurrency? currency = null;

        IOfxElement? currencyElement = parent.TryGetElement(subElementName, settings);

        if (currencyElement is not null)
        {
            currency = new OfxCurrency(
                currencyElement.GetDecimal(OfxInvestmentElementConstants.CurrencyRateElement, settings),
                currencyElement.GetString(OfxInvestmentElementConstants.CurrencySymbolElement, settings));
        }

        return currency;
    }

    /// <summary>
    /// Helper method for getting an optional OfxSecurityId for an investment element.
    /// </summary>
    /// <param name="parent">The element being processed.</param>
    /// <param name="subElementName">The name of the optional OfxSecurityId child element.</param>
    /// <param name="settings">The <see cref="OfxDocumentSettings"/> instance that define parsing behavior.</param>
    /// <returns>The <see cref="OfxSecurityId"/> or null if the child element is not present.</returns>
    public static OfxSecurityId? GetOptionalSecurityIdSubElement(IOfxElement parent, string subElementName, OfxDocumentSettings settings)
    {
        OfxSecurityId? security = null;

        IOfxElement? securityElement = parent.TryGetElement(subElementName, settings);

        if (securityElement is not null)
        {
            security = new OfxSecurityId(securityElement, settings);
        }

        return security;
    }
}
