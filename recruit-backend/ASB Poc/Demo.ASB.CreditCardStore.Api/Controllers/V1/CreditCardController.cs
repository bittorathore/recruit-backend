
using AutoMapper;
using Demo.ASB.CreditCardStore.Api.Helper;
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Application.Queries.Filters;
using Demo.ASB.CreditCardStore.Contracts.V1;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests.Queries;
using Demo.ASB.CreditCardStore.Contracts.V1.Responses;
using Demo.ASB.CreditCardStore.InfraStructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IDataEncryption _dataProtector;
        public CreditCardController(IMediator mediator, IMapper mapper, IDataEncryption dataProtector, IUriService uriService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _dataProtector = dataProtector;
            _uriService = uriService;
        }

        /// <summary>
        /// Store Credit Card information. 
        /// </summary>
        /// <remarks>
        /// A valid request contains
        /// 1) Card Holder Name : Name Can be any AlhpaNumeric value
        /// 2) Valid Credit Card Number : Only Numbers
        /// 3) Valid Expiry Card : Valid Future Date
        /// 4) Security Code : Valid number security Code
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="201">Creates a record in system</response>
        /// <response code="400">Request Validation failed.</response>
        /// <returns></returns>
        [HttpPost(ApiRoutes.CreditCards.Create)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCreditCardAsync([FromBody] CreateCreditCard request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new FaultResponse { ErrorMessage = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)) });

            var command = _mapper.Map<CreateCreditCardCommand>(request);
            command.CreditCardNumber = _dataProtector.EncryptData(request.CreditCardNumber.ToString());
            var response = await _mediator.Send(command);

            response.CreditCardNumber = _dataProtector.DecryptData(response.CreditCardNumber);
            return CreatedAtRoute("GetCreditCard", new { id = response.Id }, response);
        }

        /// <summary>
        /// Get Credit Card Detail with Card Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Record Retrieved successfully</response>
        /// <response code="404">No record exist for specified Id</response>
        /// <response code="400">Bad Request</response>
        /// <returns></returns>
        [HttpGet(ApiRoutes.CreditCards.Get, Name = "GetCreditCard")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new FaultResponse { ErrorMessage = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)) });

            var query = new GetCreditCardQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response == null) 
                return NotFound();

            response.CreditCardNumber = _dataProtector.DecryptData(response.CreditCardNumber);
            return Ok(_mapper.Map<CreditCardApiResponse>(response));
        }
        /// <summary>
        /// This Endpoint Support below function
        /// </summary>
        /// <remarks>
        /// 1. Get All Records without Pagination
        /// 2. Get Paged RecordSet by specifying pagesize and pagenumber
        /// 3. Search Credit Card with a card holder name.
        /// </remarks>
        /// <param name="filter">specify filter criteria</param>
        /// <param name="pagination">specify pagesize and pagenumber</param>
        /// <response code="200">List of record retrieved successfully.</response>
        /// <response code="204">No record exists in system</response>
        /// <returns></returns>
        [HttpGet(ApiRoutes.CreditCards.GetAll)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAllAsync([FromQuery] RequestFilter filter, [FromQuery] PaginationFilter pagination)
        {
            var query = new GetAllCreditCardsQuery { QueryFilters = _mapper.Map<RequestFilterQuery>(filter), PaginationFilters = _mapper.Map<PaginationFilterQuery>(pagination) };
            var response = await _mediator.Send(query);
            
            if (response == null)
                return  NoContent();

            response.Data = response.Data.Select(x => { x.CreditCardNumber = _dataProtector.DecryptData(x.CreditCardNumber); return x; }).ToList();

            if (pagination.PageNumber.HasValue && pagination.PageSize.HasValue)
            {
                var apiResponse = _mapper.Map<List<CreditCardApiResponse>>(response.Data);
                var pagedResponse = PaginationHelper.CreatePagedReponse<CreditCardApiResponse>(_uriService, ApiRoutes.CreditCards.GetAll, apiResponse, pagination, response.TotalRecords);
                return Ok(pagedResponse);
            }

            return Ok(new Response<List<CreditCardApiResponse>>(_mapper.Map<List<CreditCardApiResponse>>(response.Data)));
        }
    }
}
