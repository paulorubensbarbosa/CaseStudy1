using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Model
{
    public class Conta
    {

        public IOrganizationService Service { get; set; }

        public string TableName = "account";

        public Conta(IOrganizationService service)
        {
            this.Service = service;
        }

        public EntityCollection RetrieveMultipeContactsByAccount(Guid accountId) 
        {
            QueryExpression queryContacts = new QueryExpression(this.TableName);

            queryContacts.ColumnSet.AddColumn("fyi_oniveldocliente");
            queryContacts.Criteria.AddCondition("accountid", ConditionOperator.Equal, accountId);
            return this.Service.RetrieveMultiple(queryContacts);

 


        }










































        //public EntityCollection RecuperarPeloFetch(Guid id)
        //{
        //    string fetchXML = $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
        //                          <entity name='account'>
        //                            <attribute name='name' />
        //                            <attribute name='accountid' />
        //                            <attribute name='fyi_oniveldocliente' />
        //                            <order attribute='name' descending='false' />
        //                            <filter type='and'>
        //                              <condition attribute='accountid' operator='eq' uiname='D365' uitype='account' value='{94DE3A2D-D627-EC11-B6E6-00224837234E}' />
        //                            </filter>
        //                          </entity>
        //                        </fetch> ";

        //    return this.Service.RetrieveMultiple(new FetchExpression(fetchXML));
        //}


    }
}
