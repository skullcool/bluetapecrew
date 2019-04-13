﻿using System.Drawing.Imaging;
using System.Threading.Tasks;
using Api.Models.Entities;

namespace Api.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> ResizeImage(byte[] imageData, int width, int height, ImageFormat format);
        Task<Image> GetProductImageByName(string name);
        Task<Image> GetImageById(int id);
    }
}