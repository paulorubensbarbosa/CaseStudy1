using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Model
{
    public class Opportunity
    {
        public IOrganizationService Service { get; set; }

        public string TableName = "opportunity";

        public Opportunity(IOrganizationService service)
        {
            this.Service = service;
        }

        public EntityCollection RetrieveMultipeContactsByAccount(Guid OpportunityID)
        {
            QueryExpression queryContacts = new QueryExpression(this.TableName);

            
            queryContacts.ColumnSet.AddColumn("totalamount");
            queryContacts.ColumnSet.AddColumn("customerid");
            queryContacts.ColumnSet.AddColumn("parentaccountid");
            queryContacts.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, OpportunityID);
            
            queryContacts.AddLink("account", "parentaccountid", "accountid", JoinOperator.Inner);
            queryContacts.LinkEntities[0].Columns.AddColumns("fyi_oniveldocliente","telephone1");
            queryContacts.LinkEntities[0].EntityAlias = "conta";

            return this.Service.RetrieveMultiple(queryContacts);
        }

        public void UpdateOpportunity( decimal valor, string idOpportunity)
        {
            Entity opportunity = new Entity(this.TableName);
            opportunity.Id = new Guid(idOpportunity);
            opportunity["discountamount"] = valor;
            this.Service.Update(opportunity);
        }
        


    }
}
