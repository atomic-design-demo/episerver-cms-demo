namespace AtomicDesignDemo.Features.Promotion.ViewModels
{
    public class PromotionBlockViewModel
    {
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string StyleModifier { get; set; }
        public PromotionBlockLink PromoBlockLink { get; set; }
    }

    public class PromotionBlockLink
    {
        public string Url { get; set; }
    }
}
