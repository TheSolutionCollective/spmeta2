using System;
using System.Runtime.Serialization;
using SPMeta2.Attributes;
using SPMeta2.Attributes.Capabilities;
using SPMeta2.Attributes.Regression;
using SPMeta2.Definitions;
using SPMeta2.Utils;

namespace SPMeta2.Standard.Definitions.Webparts
{
    /// <summary>
    /// Allows to define and deploy 'AdvancedSearchBox' web part.
    /// </summary>
    [SPObjectType(SPObjectModelType.SSOM, "System.Web.UI.WebControls.WebParts.WebPart", "System.Web")]
    [SPObjectType(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.WebParts.WebPart", "Microsoft.SharePoint.Client")]

    [DefaultRootHost(typeof(WebDefinition))]
    [DefaultParentHost(typeof(WebPartPageDefinition))]

    [Serializable]
    [DataContract]
    [ExpectArrayExtensionMethod]

    [ExpectManyInstances]

    [ExpectWebpartType(WebPartType = "Microsoft.Office.Server.Search.WebControls.AdvancedSearchBox, Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]

    public class AdvancedSearchBoxDefinition : WebPartDefinition
    {
        #region properties

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string AndQueryTextBoxLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string DisplayGroup { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string LanguagesLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string NotQueryTextBoxLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string OrQueryTextBoxLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string PhraseQueryTextBoxLabelText { get; set; }

        /// <summary>
        /// Maps AdvancedSearchBox.Properties property.
        /// </summary>
        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string AdvancedSearchBoxProperties { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string PropertiesSectionLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string ResultTypeLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string ScopeLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string ScopeSectionLabelText { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string SearchResultPageURL { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowAndQueryTextBox { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowLanguageOptions { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowNotQueryTextBox { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowOrQueryTextBox { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowPhraseQueryTextBox { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowPropertiesSection { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowResultTypePicker { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public bool? ShowScopes { get; set; }

        [ExpectValidation]
        [DataMember]
        [ExpectNullable]
        public string TextQuerySectionLabelText { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return new ToStringResult<AdvancedSearchBoxDefinition>(this, base.ToString())
                          .ToString();
        }

        #endregion
    }
}
