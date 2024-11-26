using AutoMapper;
using ERP.MVC.Domain.Enums;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.Companies
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, string>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCompanyCommand> _logger;
        private readonly IFileUploadService _fileUploadService;

        public UpdateCompanyCommandHandler(ICompanyRepository repository, IMapper mapper, ILogger<UpdateCompanyCommand> logger, IFileUploadService fileUploadService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        public async Task<string> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _repository.GetByIdAsync(request.Id);
                if (company == null)
                {
                    throw new Exception($"Company with ID {request.Id} not found.");
                }
                string newImagePath = null;

                if (request.ImageFile != null)
                {
                    await _fileUploadService.DeleteFileAsync(company.ImageURL);
                    newImagePath = await _fileUploadService.UploadFileAsync(request.ImageFile, EntityType.Company);
                }

                _mapper.Map(request, company);
                if (!string.IsNullOrEmpty(newImagePath))
                {
                    company.ImageURL = newImagePath;
                }
                await _repository.UpdateAsync(company);
                return company.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateCompanyCommand for CompanyName: {CompanyName}", request.CompanyName);
                throw;
            }
        }
    }
}
