module.exports = {
    mode: "jit",
    theme: {
        extend: {}
    },
    content: ["./**/*.razor", "./wwwroot/index.html"],
    plugins: ['@tailwindcss/forms',]
}