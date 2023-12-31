﻿using Blog_Page.API.Core.Application.Dtos.Blog;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList
{
    public class GetBlogListQueryRequest : IRequest<List<BlogListDto>>
    {
    }
}
