﻿using ErrorOr;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Domain.Common.Errors;

namespace MoneyTracker.Infrastructure.Services;
public class FileService : IFileService
{
    private readonly string _uploadsFolder;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
    }

    public ErrorOr<byte[]> GetIcon(string fileName)
    {
        var fullPath = Path.Combine(_uploadsFolder, fileName);

        if (!File.Exists(fullPath))
            return Errors.Categories.CategoryIconDoesntExist;

        byte[] fileBytes = File.ReadAllBytes(fullPath);

        return fileBytes;
    }

    public ErrorOr<bool> DeleteImage(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            return Errors.Categories.CategoryIconPathError;

        var fullPath = Path.Combine(_uploadsFolder, Path.GetFileName(fileName));

        if (!File.Exists(fullPath))
            return Errors.Categories.CategoryIconDoesntExist;
        
        File.Delete(fullPath);

        return true;
    }

    public async Task<ErrorOr<string>> SaveImageAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return Errors.Categories.CategoryIconSavingError;

        if (!Directory.Exists(_uploadsFolder))
            Directory.CreateDirectory(_uploadsFolder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName;
    }
}

