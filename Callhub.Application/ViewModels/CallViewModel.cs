using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Callhub.Application.ViewModels
{
  public class CallViewModel
  {
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Priority { get; set; }

    [Required]
    public Guid SectorDestinId { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual IEnumerable<CallTimelineViewModel> Timeline { get; set; }
  }
}