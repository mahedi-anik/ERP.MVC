using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Enums;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ERP.MVC.Application.Commands.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result<string>>
    {
        private readonly IValidator<CreateCompanyCommand> _validator;
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;
        private readonly IFileUploadService _fileUploadService;
        public CreateCompanyCommandHandler(IValidator<CreateCompanyCommand> validator, ICompanyRepository repository, IMapper mapper, ILogger<CreateCompanyCommandHandler> logger, IFileUploadService fileUploadService)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
                if (request.ImageFile != null)
                {
                    var imagePath = await _fileUploadService.UploadFileAsync(request.ImageFile, EntityType.Company);
                    request.ImageURL = imagePath;
                }

                var company = _mapper.Map<Company>(request);
                company.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(company);
                return Result<string>.Success(company.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateCompanyCommand for CompanyName: {CompanyName}", request.CompanyName);
                throw;
            }

        }

    }
}
