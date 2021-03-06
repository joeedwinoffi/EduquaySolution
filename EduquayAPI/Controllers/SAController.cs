using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Response.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models.AdminiSupport;
using EduquayAPI.Services.SA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SAController : ControllerBase
    {
        private readonly ISAService _saService;
        private readonly ILogger<SAController> _logger;
        public SAController(ISAService saService, ILogger<SAController> logger)
        {
            _saService = saService;
            _logger = logger;
        }

        /// <summary>
        /// Used for retrieve  all States 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllStates")]
        public SAStateResponse GetStates()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllStates();
                _logger.LogInformation($"Received states {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAStateResponse { Status = "true", Message = "No states found", data = new List<StateDetails>() } 
                : new SAStateResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve states {e.StackTrace}");
                return new SAStateResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve  State by Id
        /// </summary>
        [HttpGet]
        [Route("RetrieveStateById/{id}")]
        public SAStateResponse GetState(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request for get state - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _saService.RetrieveStateById(id);
                _logger.LogInformation($"Received state by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAStateResponse { Status = "true", Message = "No states found", data = new List<StateDetails>() }
                : new SAStateResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  state by Id {e.StackTrace}");
                return new SAStateResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for Add new state
        /// </summary>
        [HttpPost]
        [Route("AddNewState")]
        public async Task<IActionResult> AddNewState(AddStateRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddStateDetail(sData);
            _logger.LogInformation($"Response - Add New State {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse 
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  state
        /// </summary>
        [HttpPost]
        [Route("UpdateState")]
        public async Task<IActionResult> UpdateState(UpdateStateRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateStatedetail(sData);
            _logger.LogInformation($"Response - update State {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all districts 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllDistricts")]
        public SADistrictResponse GetDistricts()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllDistricts();
                _logger.LogInformation($"Received Districts {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SADistrictResponse { Status = "true", Message = "No states found", data = new List<DistrictDetail>() }
                : new SADistrictResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve district {e.StackTrace}");
                return new SADistrictResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve  district by Id
        /// </summary>
        [HttpGet]
        [Route("RetrieveDistrictById/{id}")]
        public SADistrictResponse GetDistrict(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request for get district - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _saService.RetrieveDistrictById(id);
                _logger.LogInformation($"Received district by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SADistrictResponse { Status = "true", Message = "No states found", data = new List<DistrictDetail>() }
                : new SADistrictResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  district by Id {e.StackTrace}");
                return new SADistrictResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new district
        /// </summary>
        [HttpPost]
        [Route("AddNewDistrict")]
        public async Task<IActionResult> AddNewDistrict(AddDistrictRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddDistrictDetail(sData);
            _logger.LogInformation($"Response - Add New District {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  district
        /// </summary>
        [HttpPost]
        [Route("UpdateDistrict")]
        public async Task<IActionResult> UpdateDistrict(UpdateDistrictRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateDistrictDetail(sData);
            _logger.LogInformation($"Response - update district {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all blocks 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllBlocks")]
        public SABlockResponse GetBlocks()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllBlocks();
                _logger.LogInformation($"Received Blocks {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SABlockResponse { Status = "true", Message = "No block found", data = new List<BlockDetail>() }
                : new SABlockResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve block {e.StackTrace}");
                return new SABlockResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve block by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveBlockById/{id}")]
        public SABlockResponse GetBlock(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveBlockById(id);
                _logger.LogInformation($"Received block by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SABlockResponse { Status = "true", Message = "No block found", data = new List<BlockDetail>() }
                : new SABlockResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve block by id {e.StackTrace}");
                return new SABlockResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new block
        /// </summary>
        [HttpPost]
        [Route("AddNewBlock")]
        public async Task<IActionResult> AddNewBlock(AddBlockRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddBlockDetail(sData);
            _logger.LogInformation($"Response - Add New Block {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  vlock
        /// </summary>
        [HttpPost]
        [Route("UpdateBlock")]
        public async Task<IActionResult> UpdateBlock(UpdateBlockRequest uData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(uData)}");
            var data = await _saService.UpdateBlockDetail(uData);
            _logger.LogInformation($"Response - update block {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all chcs 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllCHCs")]
        public SACHCResponse GetCHCs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllCHCs();
                _logger.LogInformation($"Received all CHC {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SACHCResponse { Status = "true", Message = "No chc found", data = new List<CHCDetail>() }
                : new SACHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve chc {e.StackTrace}");
                return new SACHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve chc by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCHCById/{id}")]
        public SACHCResponse GetCHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveCHCById(id);
                _logger.LogInformation($"Received chc by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SACHCResponse { Status = "true", Message = "No chc found", data = new List<CHCDetail>() }
                : new SACHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve chc by id {e.StackTrace}");
                return new SACHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new chc
        /// </summary>
        [HttpPost]
        [Route("AddNewCHC")]
        public async Task<IActionResult> AddNewCHC(AddCHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddCHCDetail(sData);
            _logger.LogInformation($"Response - Add New CHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update chc
        /// </summary>
        [HttpPost]
        [Route("UpdateCHC")]
        public async Task<IActionResult> UpdateCHC(UpdateCHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateCHCDetail(sData);
            _logger.LogInformation($"Response - Update CHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all phcs 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllPHCs")]
        public SAPHCResponse GetPHCs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllPHCs();
                _logger.LogInformation($"Received all PHC {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAPHCResponse { Status = "true", Message = "No phc found", data = new List<PHCDetail>() }
                : new SAPHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve phc {e.StackTrace}");
                return new SAPHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve phc by id 
        /// </summary>
        [HttpGet]
        [Route("RetrievePHCById/{id}")]
        public SAPHCResponse GetPHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrievePHCById(id);
                _logger.LogInformation($"Received phc by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAPHCResponse { Status = "true", Message = "No chc found", data = new List<PHCDetail>() }
                : new SAPHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve phc by id {e.StackTrace}");
                return new SAPHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new phc
        /// </summary>
        [HttpPost]
        [Route("AddNewPHC")]
        public async Task<IActionResult> AddNewPHC(AddPHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddPHCDetail(sData);
            _logger.LogInformation($"Response - Add New PHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update phc
        /// </summary>
        [HttpPost]
        [Route("UpdatePHC")]
        public async Task<IActionResult> UpdateCHC(UpdatePHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdatePHCDetail(sData);
            _logger.LogInformation($"Response - Update PHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all scs 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllSCs")]
        public SASCResponse GetSCs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllSCs();
                _logger.LogInformation($"Received all SC {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SASCResponse { Status = "true", Message = "No sc found", data = new List<SCDetail>() }
                : new SASCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve sc {e.StackTrace}");
                return new SASCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve sc by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSCById/{id}")]
        public SASCResponse GetSC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveSCById(id);
                _logger.LogInformation($"Received sc by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SASCResponse { Status = "true", Message = "No sc found", data = new List<SCDetail>() }
                : new SASCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve ilr by id {e.StackTrace}");
                return new SASCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new sc
        /// </summary>
        [HttpPost]
        [Route("AddNewSC")]
        public async Task<IActionResult> AddNewSC(AddSCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddSCDetail(sData);
            _logger.LogInformation($"Response - Add New SC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update sc
        /// </summary>
        [HttpPost]
        [Route("UpdateSC")]
        public async Task<IActionResult> UpdateSC(UpdateSCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateSCDetail(sData);
            _logger.LogInformation($"Response - Update SC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all ILR 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllILR")]
        public SAILRResponse GetILRs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllILR();
                _logger.LogInformation($"Received all ILR {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAILRResponse { Status = "true", Message = "No ilr found", data = new List<ILRDetail>() }
                : new SAILRResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve ILR {e.StackTrace}");
                return new SAILRResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve ILR by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveILRById/{id}")]
        public SAILRResponse GetILR(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveILRById(id);
                _logger.LogInformation($"Received ilr by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAILRResponse { Status = "true", Message = "No ilr found", data = new List<ILRDetail>() }
                : new SAILRResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve ilr by id {e.StackTrace}");
                return new SAILRResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new ILR
        /// </summary>
        [HttpPost]
        [Route("AddNewILR")]
        public async Task<IActionResult> AddNewILR(AddILRRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddILRDetail(sData);
            _logger.LogInformation($"Response - Add New ILR {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update ILR
        /// </summary>
        [HttpPost]
        [Route("UpdateILR")]
        public async Task<IActionResult> UpdateILR(UpdateILRRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateILRDetail(sData);
            _logger.LogInformation($"Response - Update ILR {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all RI 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllRISites")]
        public SARIResponse GetRISitess()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllRI();
                _logger.LogInformation($"Received all RI {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SARIResponse { Status = "true", Message = "No RI found", data = new List<RISiteDetail>() }
                : new SARIResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve RI {e.StackTrace}");
                return new SARIResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve RI by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveRISiteById/{id}")]
        public SARIResponse GetRISite(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveRIById(id);
                _logger.LogInformation($"Received ri by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SARIResponse { Status = "true", Message = "No RI found", data = new List<RISiteDetail>() }
                : new SARIResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve ri by id {e.StackTrace}");
                return new SARIResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve RI by sc 
        /// </summary>
        [HttpGet]
        [Route("RetrieveRIBySC/{id}")]
        public SARIResponse GetRISiteBySC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveRIBySC(id);
                _logger.LogInformation($"Received ri by sc {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SARIResponse { Status = "true", Message = "No RI found", data = new List<RISiteDetail>() }
                : new SARIResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve ri by sc {e.StackTrace}");
                return new SARIResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new RI
        /// </summary>
        [HttpPost]
        [Route("AddNewRISites")]
        public async Task<IActionResult> AddNewRISites(AddRISitesRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddRIDetail(sData);
            _logger.LogInformation($"Response - Add New RIs {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for Update RI
        /// </summary>
        [HttpPost]
        [Route("UpdateRISite")]
        public async Task<IActionResult> UpdateRISite(UpdateRISiteRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateRIDetail(sData);
            _logger.LogInformation($"Response - Update RI {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }
    }
}
