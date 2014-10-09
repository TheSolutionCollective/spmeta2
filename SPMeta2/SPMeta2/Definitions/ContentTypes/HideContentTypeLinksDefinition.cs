﻿using System;
using System.Collections.Generic;
using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;

namespace SPMeta2.Definitions.ContentTypes
{
    [SPObjectType(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPFolder", "Microsoft.SharePoint")]
    [SPObjectType(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.Folder", "Microsoft.SharePoint.Client")]

    [DefaultRootHost(typeof(WebDefinition))]
    [DefaultParentHost(typeof(ListDefinition))]

    [Serializable]
    public class HideContentTypeLinksDefinition : DefinitionBase
    {
        #region constructors

        public HideContentTypeLinksDefinition()
        {
            IncludeContentTypes = new List<ContentTypeValue>();
            ExcludeContentTypes = new List<ContentTypeValue>();
        }

        #endregion

        #region properties

        public List<ContentTypeValue> IncludeContentTypes { get; set; }
        public List<ContentTypeValue> ExcludeContentTypes { get; set; }

        #endregion
    }
}
