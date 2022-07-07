using AutoMapper;

namespace challenge.emision.shared
{
    public class Mapper
    {
        public static List<TDestination> MapperList<TSource, TDestination>(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();
            var result = mapper.Map<List<TSource>, List<TDestination>>(source);
            return result;
        }

        public static TDestination MapperObject<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
