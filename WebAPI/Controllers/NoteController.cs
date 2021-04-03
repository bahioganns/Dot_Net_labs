using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DTO;
using BLL.Contracts;
using Domain;
using Domain.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;

        private IMapper Mapper { get; }
        private INoteCreateService NoteCreateService { get; }
        private INoteGetService NoteGetService { get; }
        private INoteUpdateService NoteUpdateService { get; }
        private INoteDeleteService NoteDeleteService { get; }

        public NoteController(ILogger<NoteController> logger, IMapper mapper, INoteCreateService noteCreateService, INoteGetService noteGetService, INoteUpdateService noteUpdateService, INoteDeleteService noteDeleteService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.NoteCreateService = noteCreateService;
            this.NoteGetService = noteGetService;
            this.NoteUpdateService = noteUpdateService;
            this.NoteDeleteService = noteDeleteService;
        }

        [HttpGet("{id}")]
        public NoteDTO GetNote(int id)
        {
            return Mapper.Map<NoteDTO>(NoteGetService.GetNote(new NoteIdentityModel(id)));
        }

        [HttpPut("{id}")]
        public NoteDTO UpdateNote(int id, NoteDTO note)
        {
            var identityModel = new NoteIdentityModel(id);
            var updateModel = Mapper.Map<NoteUpdateModel>(note);

            Note res = NoteUpdateService.UpdateNote(identityModel, updateModel);

            return Mapper.Map<NoteDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeleteNote(int id)
        {
            var identityModel = new NoteIdentityModel(id);
            NoteDeleteService.DeleteNote(identityModel);
        }
    }
}
