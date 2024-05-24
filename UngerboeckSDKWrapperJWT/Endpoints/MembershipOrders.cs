using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class MembershipOrders : Base<MembershipOrdersModel>
  {
    protected internal MembershipOrders(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<MembershipOrdersModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public MembershipOrdersModel Get(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.MembershipOrders options = null)
    {
      return base.Get(new { orgCode, orderNumber }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public MembershipOrdersModel Update(MembershipOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.MembershipOrders options = null)
    {
      return base.Update(new { model.OrganizationCode, model.OrderNumber }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public MembershipOrdersModel Add(MembershipOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.MembershipOrders options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to prepare a membership order for invoicing.  This process replicates the "Prepare Order" functionality found in v20's "Prepare Membership Orders For Invoicing" window.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>The response content contains the newly created Membership Order number (type MB).</returns>
    public string PrepareMembershipOrderForInvoicing(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.MembershipOrders options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> prepareMembershipOrderTask = PutAsync<object, HttpResponseMessage>(Client, $"MembershipOrders/{orgCode}/{orderNumber}/PrepareMembershipOrderForInvoicing", null, options);
      var response = GetResponseContentAsString(prepareMembershipOrderTask);
      return response.Result;      
    }
  }
}
