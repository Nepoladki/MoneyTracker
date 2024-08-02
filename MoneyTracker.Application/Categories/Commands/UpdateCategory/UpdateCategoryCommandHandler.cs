﻿using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Common.Errors;
using MapsterMapper;

namespace MoneyTracker.Application.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<Guid>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate if such category Exists
        if (await _categoryRepository.GetCategoryByIdAsync(request.Id) is not Category category)
            return Errors.Categories.CategoryNotFound;

        // Validate that updated category doesn't equal existing one
        if (request.CategoryName == category.CategoryName && request.IsPublic == category.IsPublic)
            return Errors.Categories.NoUpdates;

        _mapper.Map(request, category);

        // Saving updated category in db
        if (!await _categoryRepository.SaveAsync())
            return Errors.Categories.SavingError;

        return category.Id;        
    }
}
