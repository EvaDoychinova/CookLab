namespace CookLab.Models.ViewModels
{
    using System;

    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalPagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);

        public bool HasPreviousPage => this.CurrentPage > 1;

        public int PreviousPage => this.CurrentPage - 1;

        public bool HasNextPage => this.CurrentPage < this.TotalPagesCount;

        public int NextPage => this.CurrentPage + 1;
    }
}
