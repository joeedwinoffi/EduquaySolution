﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;
        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddBlock(BlockRequest bData)
        {
            try
            {
                var block = _blockService.AddBlock(bData);
                return string.IsNullOrEmpty(block) ? $"Unable to add block data" : block;
            }
            catch (Exception e)
            {
                return $"Unable to add block data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public BlockResponse GetBlocks()
        {
            try
            {
                var blocks = _blockService.Retrieve();
                return blocks.Count == 0 ? new BlockResponse { Status = "true", Message = "No blocks found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public BlockResponse GetBlock(int code)
        {
            try
            {
                var blocks = _blockService.Retrieve(code);
                return blocks .Count == 0 ? new BlockResponse { Status = "true", Message = "No block found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

    }
}