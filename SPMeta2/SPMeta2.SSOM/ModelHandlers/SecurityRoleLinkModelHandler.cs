﻿using System;
using Microsoft.SharePoint;
using SPMeta2.Common;
using SPMeta2.Definitions;
using SPMeta2.ModelHandlers;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Utils;
using SPMeta2.Exceptions;

namespace SPMeta2.SSOM.ModelHandlers
{
    public class SecurityRoleLinkModelHandler : SSOMModelHandlerBase
    {
        #region methods

        public override Type TargetType
        {
            get { return typeof(SecurityRoleLinkDefinition); }
        }

        private SPSecurableObject ExtractSecurableObject(object modelHost)
        {
            if (modelHost is SPSecurableObject)
                return modelHost as SPSecurableObject;

            if (modelHost is SiteModelHost)
                return (modelHost as SiteModelHost).HostSite.RootWeb;

            if (modelHost is WebModelHost)
                return (modelHost as WebModelHost).HostWeb;

            if (modelHost is ListModelHost)
                return (modelHost as ListModelHost).CurrentList;

            if (modelHost is FolderModelHost)
                return (modelHost as FolderModelHost).CurrentLibraryFolder.Item;

            if (modelHost is WebpartPageModelHost)
                return (modelHost as WebpartPageModelHost).PageListItem;

            throw new SPMeta2NotImplementedException(string.Format("Model host of type:[{0}] is not supported by SecurityGroupLinkModelHandler yet.",
                modelHost.GetType()));
        }

        protected override void DeployModelInternal(object modelHost, DefinitionBase model)
        {
            var modelHostContext = modelHost.WithAssertAndCast<SecurityGroupModelHost>("modelHost", value => value.RequireNotNull());
            var securityRoleLinkModel = model.WithAssertAndCast<SecurityRoleLinkDefinition>("model", value => value.RequireNotNull());

            var securableObject = modelHostContext.SecurableObject;
            var securityGroup = modelHostContext.SecurityGroup;

            if (securableObject == null || securableObject is SPWeb)
            {
                // this is SPGroup -> SPRoleLink deployment
                ProcessSPGroupHost(securityGroup, securityGroup, securityRoleLinkModel);
            }
            else if (securableObject is SPSecurableObject)
            {
                ProcessSPSecurableObjectHost(securableObject as SPSecurableObject, securityGroup, securityRoleLinkModel);
            }
            else
            {
                throw new Exception(string.Format("modelHost of type:[{0}] is not supported.", modelHost.GetType()));
            }
        }

        private SPWeb ExtractWeb(object modelHost)
        {
            if (modelHost is SPWeb)
                return modelHost as SPWeb;

            if (modelHost is SPList)
                return (modelHost as SPList).ParentWeb;

            if (modelHost is SPListItem)
                return (modelHost as SPListItem).ParentList.ParentWeb;

            if (modelHost is SiteModelHost)
                return (modelHost as SiteModelHost).HostSite.RootWeb;

            if (modelHost is WebModelHost)
                return (modelHost as WebModelHost).HostWeb;

            if (modelHost is ListModelHost)
                return (modelHost as ListModelHost).CurrentList.ParentWeb;

            if (modelHost is FolderModelHost)
                return (modelHost as FolderModelHost).CurrentLibraryFolder.ParentWeb;

            throw new Exception(string.Format("modelHost with type [{0}] is not supported.", modelHost.GetType()));
        }

        private void ProcessSPSecurableObjectHost(SPSecurableObject targetSecurableObject, SPGroup securityGroup,
            SecurityRoleLinkDefinition securityRoleLinkModel)
        {
            //// TODO
            // need common validation infrastructure 
            var web = ExtractWeb(targetSecurableObject);

            var roleAssignment = new SPRoleAssignment(securityGroup);

            var role = web.RoleDefinitions[securityRoleLinkModel.SecurityRoleName];

            if (!roleAssignment.RoleDefinitionBindings.Contains(role))
            {
                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioning,
                    Object = null,
                    ObjectType = typeof(SPRoleDefinition),
                    ObjectDefinition = securityRoleLinkModel,
                    ModelHost = targetSecurableObject
                });

                roleAssignment.RoleDefinitionBindings.Add(role);
            }
            else
            {
                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioning,
                    Object = role,
                    ObjectType = typeof(SPRoleDefinition),
                    ObjectDefinition = securityRoleLinkModel,
                    ModelHost = targetSecurableObject
                });

            }

            targetSecurableObject.RoleAssignments.Add(roleAssignment);

            InvokeOnModelEvent(this, new ModelEventArgs
            {
                CurrentModelNode = null,
                Model = null,
                EventType = ModelEventType.OnProvisioned,
                Object = role,
                ObjectType = typeof(SPRoleDefinition),
                ObjectDefinition = securityRoleLinkModel,
                ModelHost = targetSecurableObject
            });
        }

        private void ProcessSPGroupHost(SPGroup modelHost, SPGroup securityGroup, SecurityRoleLinkDefinition securityRoleLinkModel)
        {
            // TODO
            // need common validation infrastructure 
            var web = securityGroup.ParentWeb;

            var securityRoleAssignment = new SPRoleAssignment(securityGroup);
            SPRoleDefinition roleDefinition = null;

            if (!string.IsNullOrEmpty(securityRoleLinkModel.SecurityRoleName))
            {
                roleDefinition = web.RoleDefinitions[securityRoleLinkModel.SecurityRoleName];
            }
            else if (!string.IsNullOrEmpty(securityRoleLinkModel.SecurityRoleType))
            {
                var securityRoleType = (SPRoleType)Enum.Parse(typeof(SPRoleType), securityRoleLinkModel.SecurityRoleType, true);
                roleDefinition = web.RoleDefinitions.GetByType(securityRoleType);
            }
            else
            {
                roleDefinition = web.RoleDefinitions.GetById(securityRoleLinkModel.SecurityRoleId);
            }

            if (!securityRoleAssignment.RoleDefinitionBindings.Contains(roleDefinition))
            {
                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioning,
                    Object = null,
                    ObjectType = typeof(SPRoleDefinition),
                    ObjectDefinition = securityRoleLinkModel,
                    ModelHost = modelHost
                });

                securityRoleAssignment.RoleDefinitionBindings.Add(roleDefinition);
            }
            else
            {
                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioning,
                    Object = roleDefinition,
                    ObjectType = typeof(SPRoleDefinition),
                    ObjectDefinition = securityRoleLinkModel,
                    ModelHost = modelHost
                });
            }

            InvokeOnModelEvent(this, new ModelEventArgs
            {
                CurrentModelNode = null,
                Model = null,
                EventType = ModelEventType.OnProvisioned,
                Object = roleDefinition,
                ObjectType = typeof(SPRoleDefinition),
                ObjectDefinition = securityRoleLinkModel,
                ModelHost = modelHost
            });

            web.RoleAssignments.Add(securityRoleAssignment);
            web.Update();
        }

        #endregion
    }
}