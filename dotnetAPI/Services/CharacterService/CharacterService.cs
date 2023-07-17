

using System;
using dotnetAPI.Models;

namespace dotnetAPI.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
        private IMapper _mapper;
        private readonly DataContext context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this.context = context;
        }

       
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id=1, Name = "Mac"}
        };
        

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            context.Characters.Add(character);
            await context.SaveChangesAsync();
            serviceResponse.Data = await context.Characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            var foundCharacher = await context.Characters.FirstOrDefaultAsync(c=> c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(foundCharacher);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            var characters = await context.Characters.ToListAsync<Character>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList(); ;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            {
                var character = await context.Characters.FirstOrDefaultAsync<Character>(c => c.Id == updateCharacter.Id);

                if(character is null)
                {
                    throw new Exception($"The charactr with ID::'{updateCharacter.Id}' NotFound!");
                }

                var character1 = _mapper.Map(updateCharacter, character);

                await context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character1);
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
           
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

            try
            {
                var character = await context.Characters.FirstOrDefaultAsync<Character>(c => c.Id == Id);

                if (character is null)
                {
                    throw new Exception($"The charactr with ID::'{Id}' NotFound!");
                }

                var deletedCharacter = characters.Remove(character);

                await context.SaveChangesAsync();
         
                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}

