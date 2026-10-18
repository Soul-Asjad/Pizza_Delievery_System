using Microsoft.EntityFrameworkCore;

namespace Pizza_Delievery_System.Models
{
    public class PizzaDBContext : DbContext
    {
        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<PizzaBase> PizzaBase { get; set; }
        public DbSet<Sauce> Sauce { get; set; }
        public DbSet<Cheese> Cheese { get; set; }
        public DbSet<Vegetable> Vegetable { get; set; }
        public DbSet<CustomPizza> CustomPizza { get; set; }
        public DbSet<CustomPizzaVegetable> CustomPizzaVegetable { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<EmailVerificationToken> EmailVerificationToken { get; set; }
        public DbSet<PasswordResetToken> PasswordResetToken { get; set; }
        public DbSet<Pizza_Deals> Pizza_Deals { get; set; }
        public DbSet<DealPizza> DealPizza { get; set; }
        public DbSet<Toppings> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // =========================
            // USER → ADDRESS
            // =========================

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Users)
                .WithMany()
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // USER → CART
            // =========================

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Users)
                .WithMany()
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // USER → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizza>()
                .HasOne(cp => cp.User)
                .WithMany()
                .HasForeignKey(cp => cp.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // USER → ORDER
            // =========================

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // USER → EMAIL VERIFICATION
            // =========================

            modelBuilder.Entity<EmailVerificationToken>()
                .HasOne(e => e.Users)
                .WithMany()
                .HasForeignKey(e => e.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // USER → PASSWORD RESET
            // =========================

            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(p => p.Users)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // ADDRESS → ORDER
            // =========================

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.AddressID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // CART → CART ITEM
            // =========================

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany()
                .HasForeignKey(ci => ci.CartID)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // PIZZA → CART ITEM
            // =========================

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Pizza)
                .WithMany()
                .HasForeignKey(ci => ci.PizzaID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // CUSTOM PIZZA → CART ITEM
            // =========================

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.CustomPizza)
                .WithMany()
                .HasForeignKey(ci => ci.CustomPizzaID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // PIZZA → ORDER ITEM
            // =========================

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Pizza)
                .WithMany()
                .HasForeignKey(oi => oi.PizzaID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // CUSTOM PIZZA → ORDER ITEM
            // =========================

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.CustomPizza)
                .WithMany()
                .HasForeignKey(oi => oi.CustomPizzaID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // ORDER → ORDER ITEM
            // =========================

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Orders)
                .WithMany()
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // ORDER → PAYMENT
            // =========================

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Orders)
                .WithMany()
                .HasForeignKey(p => p.OrderID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // PIZZA BASE → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizza>()
                .HasOne(cp => cp.PizzaBase)
                .WithMany()
                .HasForeignKey(cp => cp.PizzaBaseID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // SAUCE → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizza>()
                .HasOne(cp => cp.Sauce)
                .WithMany()
                .HasForeignKey(cp => cp.SauceID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // CHEESE → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizza>()
                .HasOne(cp => cp.Cheese)
                .WithMany()
                .HasForeignKey(cp => cp.CheeseID)
                .OnDelete(DeleteBehavior.NoAction);


            // =========================
            // CUSTOM PIZZA → VEGETABLE
            // =========================

            modelBuilder.Entity<CustomPizzaVegetable>()
                .HasOne(cpv => cpv.CustomPizza)
                .WithMany()
                .HasForeignKey(cpv => cpv.CustomPizzaID)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // VEGETABLE → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizzaVegetable>()
                .HasOne(cpv => cpv.Vegetable)
                .WithMany()
                .HasForeignKey(cpv => cpv.VegetableID)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // Topping → CUSTOM PIZZA
            // =========================

            modelBuilder.Entity<CustomPizza>()
                .HasOne(cp => cp.Toppings)
                .WithMany()
                .HasForeignKey(cp => cp.ToppingID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}