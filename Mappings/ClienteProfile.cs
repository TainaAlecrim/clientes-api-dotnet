using AutoMapper;
using ClientesApi.Models;
using ClientesApi.DTOs;
using ClientesApi.Dtos;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        // Request → Entidade
        CreateMap<ClienteRequest, Cliente>();

        // Entidade → Response
        CreateMap<Cliente, ClienteResponse>();
    }
}
