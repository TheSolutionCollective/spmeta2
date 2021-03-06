using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Standard.Syntax
{

    [Serializable]
    [DataContract]
    public class AdvancedSearchBoxModelNode : WebPartModelNode
    {

    }

    public static class AdvancedSearchBoxDefinitionSyntax
    {
        #region methods

        public static TModelNode AddAdvancedSearchBox<TModelNode>(this TModelNode model, AdvancedSearchBoxDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddAdvancedSearchBox(model, definition, null);
        }

        public static TModelNode AddAdvancedSearchBox<TModelNode>(this TModelNode model, AdvancedSearchBoxDefinition definition,
            Action<AdvancedSearchBoxModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddAdvancedSearchBoxes<TModelNode>(this TModelNode model, IEnumerable<AdvancedSearchBoxDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
