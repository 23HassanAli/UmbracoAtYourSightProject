import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    build: {
        outDir: '../../../',
        rollupOptions: {
            output: {
                entryFileNames: `App_Plugins/GoogleAnalyticsSection/assets/[name].js`,
                chunkFileNames: `App_Plugins/GoogleAnalyticsSection/assets/[name].js`,
                assetFileNames: `App_Plugins/GoogleAnalyticsSection/assets/[name].[ext]`
            }
        }
    }
})