using BeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeeTracker
{
    public partial class _Default : Page
    {
        // Ten bees of each type.
        private const int BEE_TYPE_COUNT = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only ones in the application lifecycle.
            if (!IsPostBack) // Ignore if postback.
            {
                // Define the default bees list.
                List<Bee> bees = GetBees();
                // Define a session variable holding this list.
                // Saving it to the session variable simulates a put request
                // to a db model.
                Session["bees"] = bees;
                // Bind the grid.
                BindBeesGrid();
            }
        }

        /// <summary>
        /// Binds the bees grid.
        /// </summary>
        private void BindBeesGrid()
        {
            // Get the latest snapshot of bees and bind it to the grid.
            gvBees.DataSource = Session["bees"] as List<Bee>;
            gvBees.DataBind();
        }

        /// <summary>
        /// Function that returns a default list of bees (10 of each type).
        /// </summary>
        private List<Bee> GetBees()
        {
            List<Bee> bees = new List<Bee>();

            // For each bee type.
            foreach (BeeType beeType in ((BeeType[])Enum.GetValues(typeof(BeeType))))
            {
                // Generate 10 bees.
                for (int i = 0; i < BEE_TYPE_COUNT; i++)
                {
                    bees.Add(new Bee(beeType));
                }
            }

            return bees;
        }

        /// <summary>
        /// Handles the damage button click.
        /// </summary>
        protected void LnkDamage_Click(object sender, EventArgs e)
        {
            // Ge the bee unique id from sender.
            Guid beeId = Guid.Parse((sender as LinkButton).CommandArgument);
            // Get the latest snapshot of the bees from the session.
            List<Bee> bees = Session["bees"] as List<Bee>;
            // Get the matching bee (basesd on the button arg passed).
            Bee bee = bees.Where(b => b.ID == beeId).FirstOrDefault();
            // Generate a damage percentage.
            int damage = new Random().Next(81);
            // Apply damage in place.
            bee.Damage(damage);
            // Re-define the bees session variable.
            Session["bees"] = bees;

            // Re-bind the grid again.
            BindBeesGrid();
        }
    }
}