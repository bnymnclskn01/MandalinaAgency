!function(e){"use strict";async function t(n){await dsnGrid.destoryBuild(),await i("poster"),await i("src"),await i("srcset"),await i("bg"),n||(window.$animate=await function(){const t=Linear.easeNone;return{allInt:function(){this.clearControl().then(()=>{this.headerPages()}).then(()=>{this.animations()}).then(()=>{this.parallaxMulti()}).then(()=>{this.parallaxImg()}).then(()=>{this.moveSection()}).then(()=>{this.parallaxImgHover()}).then(()=>{this.dsnScrollTop()}).then(()=>{this.translateSection()}).then(()=>{$effectScroll.scrollNavigate()})},clearControl:async function(){$controller.destroy(!0),$controller=new ScrollMagic.Controller},parallaxImg:async function(){let t=this;e('[data-dsn-grid="move-up"]').each((function(){const n=gsap.timeline({yoyo:!0});t.tweenImage(e(this),n);let i=dsnGrid.tweenMaxParallax($controller).addParrlax({id:this,triggerHook:dsnGrid.getData(this,"triggerhook",1),duration:dsnGrid.getData(this,"duration","200%"),tween:n});i&&$scene.push(i),i=null}))},tweenImage:function(e,n){let i=e.find("img:not(.hidden) , video");if(e.attr("data-dsn-grid","moveUp"),i.length>0){let a=dsnGrid.getData(i,"speed","180"),s={scale:1,y:i.hasClass("has-opposite-direction")?"-="+a:"+="+a,skewY:0,yoyo:!0,ease:t,overwrite:"none"};gsap.set(i,{height:"+="+a,top:i.hasClass("has-opposite-direction")?0:"-="+a},0),i.hasClass("has-scale")&&(s.scale=1.1),i.css("perspective",e.width()>1e3?1e3:e.width()),n.to(i,1,s,0)}},parallaxMulti:async function(){let t=this;e("[data-dsn-animate-multi]").each((function(){dsnGrid.getData(this,"animate-multi");const n=gsap.timeline({yoyo:!0,overwrite:"none"});e(this).find('[data-dsn-grid="move-up"]').each((function(){t.tweenImage(e(this),n)})),e(this).find('[data-dsn-grid="move-section"]').each((function(){t.tweenMoveSection.bind(this,n)()}));let i=dsnGrid.getData(this,"duration","200%"),a=dsnGrid.getData(this,"triggerhook",1);0===i&&(i=e(this).outerHeight()*(a+1));let s=dsnGrid.tweenMaxParallax($controller).addParrlax({id:this,triggerHook:a,duration:i,tween:n});s&&$scene.push(s),s=null}))},animations:async function(){let n=this;e('[data-dsn-animate="section"]').each((function(){dsnGrid.getData(this,"animate");const i={$this:e(this),gsap:gsap.timeline({paused:!0,ease:t,overwrite:"none"})};n.animateFade(i,e(this).find(".dsn-up")).then(()=>{n.animateText(i,e(this).find(".dsn-text"))}).then(()=>{e(this).find(".line").length&&n.animateLine(i)}).then(()=>{n.animateSkills(i,e(this).find(".skills-item .fill"))}).then(()=>{n.animateNumbers(i,e(this).find(".has-animate-number"))}).then(()=>{i.gsap._totalDuration=1;const t=dsnGrid.tweenMaxParallax().addParrlax({id:this,reverse:!1,triggerHook:.5,duration:0,tween:i.gsap});i.$this.find(".circular-item .circle").length&&(i.$this.find(".circular-item .circle").circleProgress({size:160,lineCap:"round",startAngle:-Math.PI,fill:{gradient:["#5a0e0e","#e82a2a"]}}),t.on("start",(function(){i.$this.find(".circular-item .circle").circleProgress({}).on("circle-animation-progress",(function(t,n){e(this).find("h4").html(Math.round(t.target.dataset.value*n*100)+"%")}))})))})}))},animateFade:async function(e,t,n=0){t.length&&e.gsap.staggerFromTo(t,.8,{y:20,opacity:0},{y:0,opacity:1,delay:n,overwrite:"none",ease:Back.easeOut.config(1.7)},.2,0)},animateText:function(t,n){n.length&&n.each((function(){dsnGrid.convertTextLine(this,"words").removeSpace().el,e(this).addClass("overflow-hidden"),t.gsap.staggerFrom(e(this).find(".dsn-word-wrapper"),.6,{willChange:"transform",transformOrigin:"left",opacity:0,scaleX:2,ease:Back.easeOut.config(2)},.1,0)}))},animateLine:function(e,t){e.gsap.addLabel("line",0),e.$this.find(".line.line-top").length&&e.gsap.from(e.$this.find(".line.line-top").toArray(),1,{scaleX:0,transformOrigin:"right"},"line"),e.$this.find(".line.line-left").length&&e.gsap.from(e.$this.find(".line.line-left").toArray(),1,{scaleY:0,transformOrigin:"top"},"line+=1"),e.$this.find(".line.line-bottom").length&&e.gsap.from(e.$this.find(".line.line-bottom").toArray(),1,{scaleX:0,transformOrigin:"left"},"line+=2"),e.$this.find(".line.line-right").length&&e.gsap.from(e.$this.find(".line.line-right").toArray(),1,{scaleY:0,transformOrigin:"bottom"},"line+=3")},animateSkills:function(t,n){n.each((function(n){let i=e(this);t.gsap.to(i,1,{width:i.data("width"),onUpdate:function(){i.find(".number").text((i.width()/i.parent().width()*100).toFixed(0)+"%")},onComplete:function(){i=null}},.2*n)}))},animateNumbers:function(t,n){t.gsap.addLabel("number",0),n.each((function(n){let i=e(this),a={value:0};t.gsap.to(a,4,{value:i.text(),ease:Back.easeOut.config(1.2),onUpdate:function(){i.text(dsnGrid.numberText(a.value.toFixed(0)))},onComplete:function(){i=a=null}},"number+="+.2*n)}))},headerPages:function(){e(".dsn-header-parallax").each((function(){let n=e(this),i=n.find(".dsn-hero-parallax-img"),a=n.find(".dsn-hero-parallax-title");const s=gsap.timeline();i.length&&s.to(i,{y:"30%",yoyo:!0,ease:t,overwrite:"none",scale:n.hasClass("has-scale")?1.2:1},0),s.to(a,{y:150,yoyo:!0,autoAlpha:0,ease:t,overwrite:"none"},0),dsnGrid.tweenMaxParallax($controller).addParrlax({id:this,triggerHook:0,duration:"100%",tween:s}),i=n=void 0}))},moveSection:function(){let t=this;e('[data-dsn-grid="move-section"]').each((function(){let n=e(this);const i=gsap.timeline({yoyo:!0});t.tweenMoveSection.bind(this,i)();const a=dsnGrid.tweenMaxParallax($controller).addParrlax({id:this,triggerHook:dsnGrid.getData(n,"triggerhook",1),duration:dsnGrid.getData(n,"duration","150%"),tween:i});$scene.push(a),n=null}))},tweenMoveSection:function(n){let i=e(this);dsnGrid.getData(this,"grid"),i.addClass("dsn-move-section"),"tablet"===dsnGrid.getData(this,"responsive")&&dsnGrid.isMobile()||n.to(i,1,{y:dsnGrid.getData(i,"move",-150),autoAlpha:dsnGrid.getData(i,"opacity",i.css("opacity")),ease:t,overwrite:"none"},0)},parallaxImgHover:function(){dsnGrid.isMobile()||(e('[data-dsn="parallax"]').each((function(){let t=e(this);t.removeAttr("data-dsn"),dsnGrid.parallaxMoveElement(t,dsnGrid.getData(t,"move",20),dsnGrid.getData(t,"speed",.5),t.find(".dsn-parallax-rev").get(0),t.hasClass("image-zoom")),t=null})),e('[data-dsn-parallax="parallax"]').each((function(){let t=e(this);t.removeAttr("data-dsn-parallax"),t.removeAttr("data-dsn-move"),dsnGrid.parallaxMoveElement({target:t,element:t.find(".dsn-move-img")},dsnGrid.getData(t,"move",20),dsnGrid.getData(t,"speed",.1),t.find(".dsn-parallax-rev"),t.hasClass("image-zoom")),t=null})))},dsnScrollTop:function(){const n=$effectScroll.isScroller(!0)?e("#dsn-scrollbar .scroll-content"):e("#dsn-scrollbar"),i=e(".scroll-to-top");if(!n.length||!i.length)return;const a=gsap.timeline();a.to(i.find("> img"),1,{rotation:n.height()/2,ease:t,yoyo:!0},0);const s=dsnGrid.tweenMaxParallax($controller).addParrlax({id:n,triggerHook:0,duration:dsnGrid.getHeightScroll(),tween:a});s.on("progress",(function(t){10*t.progress>.5?gsap.to(i,{right:50,yoyo:!0}):gsap.to(i,{right:-150,yoyo:!0}),e(".scroll-to-top .box-number span").text((100*t.progress).toFixed(0)+"%"),s.duration(dsnGrid.getHeightScroll())}))},translateSection:function(){e(".section-image.section-move-image .transform-move-section").each((function(){const t=gsap.timeline();let n=0;e(this).find(".swiper-slide").each((function(){n+=e(this).outerWidth()})),e(this).append(e(this).find(".swiper-slide").clone()),e(this).append(e(this).find(".swiper-slide").clone()),n-=e(this).width(),e(this).hasClass("move-left")?t.to(this,{x:-1*n}):t.from(this,{x:-1*n});let i=dsnGrid.tweenMaxParallax($controller).addParrlax({id:this,triggerHook:dsnGrid.getData(this,"triggerhook",1),duration:dsnGrid.getData(this,"duration","200%"),tween:t});i&&$scene.push(i)}))}}}(),await function(){const t=e(".site-header");return{init:function(){if(!t.length)return;this.cutterText(),this.hamburgerOpen()},cutterText:function(){let e=t.find(".menu-icon .text-menu");if(e.length<=0)return;let n=e.find(".text-button"),i=e.find(".text-open"),a=e.find(".text-close");dsnGrid.convertTextLine(n),dsnGrid.convertTextLine(i),dsnGrid.convertTextLine(a),a=null,i=null,n=null,e=null},hamburgerOpen:function(){const n=t.find(".menu-icon"),i=t.find(".main-navigation");let a=gsap.timeline({paused:!0,onReverseComplete:function(){setTimeout((function(){n.find(".icon-top , .icon-bottom").css("transform","").css("display","")}),50)}});var s=gsap.timeline({onReverseComplete:function(){s=gsap.timeline()}});let o=Power3.easeOut;a.set(n.find(".icon-center"),{display:"none"}),a.to(n.find(".icon-top"),.5,{width:23,rotation:45,top:0,ease:o}),a.to(n.find(".icon-bottom"),.5,{width:23,rotation:-45,top:0,ease:o},0),a.call((function(){n.toggleClass("nav-active"),t.toggleClass("nav-active")}),0),a.to(i,.5,{y:"0%",autoAlpha:1,ease:o},0),a.fromTo(i,.5,{y:"-100%",autoAlpha:0},{y:"0%",autoAlpha:1,ease:Expo.easeInOut},0),a.staggerTo(i.find("ul.extend-container > li > a .dsn-title-menu"),.5,{autoAlpha:1,y:0,ease:Back.easeOut.config(1.7)},.05),a.set(i.find("ul.extend-container > li > a .dsn-meta-menu"),{autoAlpha:1,ease:o}),a.to(i.find(".container-content"),1,{autoAlpha:1},"-=1"),a.reverse(),i.find("ul.extend-container > li.dsn-drop-down").on("click",(function(t){t.stopPropagation(),s._tDur>0||((s=gsap.timeline({onReverseComplete:function(){s=gsap.timeline()}})).set(e(this).find("ul"),{display:"flex"}),s.to(i.find("ul.extend-container > li > a ").find(".dsn-title-menu , .dsn-meta-menu"),.5,{y:-30,autoAlpha:0,ease:Back.easeIn.config(1.7)}),s.set(".site-header .extend-container .main-navigation ul.extend-container li",{overflow:"hidden"}),s.staggerFromTo(e(this).find("ul li"),.5,{x:50,autoAlpha:0},{x:0,autoAlpha:1,ease:Back.easeOut.config(1.7)},.1))})),n.off("click"),n.on("click",(function(){a.isActive()||(s.reverse(-1),a.reversed(!a.reversed()),s=gsap.timeline())}));let l=e(".dsn-back-menu");l.off("click"),l.on("click",(function(e){e.stopPropagation(),s.reverse()}))}}}().init(),await dsnGrid.removeWhiteSpace(".site-header ul.extend-container li > a"),await void e(".day-night").on("click",(function(){const t=e(".v-dark"),n=e(".v-light");$body.toggleClass("v-dark"),t.removeClass("v-dark").addClass("v-light"),n.addClass("v-dark").removeClass("v-light")}))),n&&await a(n),e("a.vid").YouTubePopUp(),await function(t){const n=e(".contact-btn");t&&n.off("click");n.on("click",()=>{$body.toggleClass("dsn-show-contact")})}(),await $effectScroll.start(),await function(){$wind.off("scroll");const t=e(".wrapper");let n=0;var i=t.offset(),a=t.find("> *:first-child"),s=0;a.length&&(i="HEADER"===a.get(0).nodeName?a.outerHeight():void 0!==i?i.top:70);$effectScroll.getListener((function(e){n="scroll"===e.type?$wind.scrollTop():e.offset.y,i>170&&(i-=100),n>i?s<n?$body.addClass("nav-bg").addClass("hide-nav"):$body.removeClass("hide-nav"):$body.removeClass("nav-bg").removeClass("hide-nav"),s=n}))}(),await $animate.allInt(),await(e(".dsn-isotope").each((t,n)=>{setTimeout((function(){const t=e.extend(!0,{itemSelector:dsnGrid.getData(n,"item",".grid-item")},dsnGrid.getData(n,"isotope",{}));t.space&&dsnGrid.convertToJQuery(n).attr("style","--gutter:"+t.space+"px;"),e(n).masonry(t)}),500)}),void e(".dsn-filter").each((function(){const t=e(this).find(".filterings .filtering "),n=e(this).find(".dsn-isotope");t.length&&n.length&&(n.isotope(),t.find("button").off("click"),t.find("button").on("click",(function(){e(this).addClass("active").siblings().removeClass("active"),n.isotope({filter:e(this).attr("data-filter")})})))}))),await function(){let t=[];return{swiper:function(n,i){n=dsnGrid.convertToJQuery(n),i=e.extend(!0,{slidesPerView:1,centeredSlides:!1,spaceBetween:0,grabCursor:!0,speed:1e3,parallax:!0,loop:!0,autoHeight:!0,slideToClickedSlide:!0,pagination:{el:n.find(".swiper-pagination").get(0),clickable:!0},navigation:{nextEl:n.find(".swiper-next ,.next-container").get(0),prevEl:n.find(".swiper-prev , .prev-container").get(0)}},i),i=this.dsnProgressIndicator(n,i);let a=new Swiper(n.find(".swiper-container").get(0),i);dsnGrid.addSwiper(a);const s=dsnGrid.getData(n,"controller");s&&(t[s]=a)},dsnProgressIndicator:function(e,t){return e.find(".dsn-progress-indicator").length?(t.pagination={el:e.find(".dsn-controls .dsn-numbers span:not(.full-number)").get(0),type:"custom",clickable:!0,renderCustom:function(t,n,i){return e.find(".dsn-controls .dsn-numbers span.full-number").html(dsnGrid.numberText(i)),gsap.to(e.find(".dsn-controls .dsn-progress .dsn-progress-indicator"),1,{width:n/i*100+"%"}),dsnGrid.numberText(n)}},t):t},run:function(){let n=this;e(".dsn-swiper").each((function(){let t=dsnGrid.getData(this,"option",{}),i=e(this).parent().find(dsnGrid.getData(this,"controllers"));i.length&&(t.thumbs={swiper:{el:i.find(".swiper-container").get(0),allowTouchMove:!1,slidesPerView:1,speed:t.speed||1e3,parallax:!0,autoHeight:!0}}),t.breakpoints={768:{slidesPerView:t.slidesPerView>1?t.slidesPerView>1.5?2:1.3:1,spaceBetween:t.slidesPerView>1?t.spaceBetween>31?30:t.spaceBetween:0},992:{slidesPerView:t.slidesPerView,spaceBetween:t.spaceBetween||0},575:{slidesPerView:1,spaceBetween:0}},i.length&&(t.thumbs={swiper:{el:i.find(".swiper-container").get(0),allowTouchMove:!1,slidesPerView:1,speed:t.speed||1e3,parallax:!0,autoHeight:!0}},t.breakpoints[768]={slidesPerView:1,spaceBetween:0}),n.swiper(this,t)}));const i=t["slide-inner"],a=t["bg-container"];i&&a&&(i.controller.control=a,a.controller.control=i)}}}().run(),await void e(".dsn-accordion").each((function(){const t=e(this),n=t.find(".accordion__question");n.on("click",(function(){const i=e(this).next();t.find(".accordion__answer").not(i).slideUp(400),n.not(this).removeClass("expanded"),e(this).toggleClass("expanded"),i.slideToggle(400)}))})),await function(){let t=e(".map-custom");if(!t.length)return void(t=null);if(!e("#map_api").length){let e="AIzaSyA5bpEs3xlB8vhxNFErwoo3MXR64uavf6Y",t=document.createElement("script");t.type="text/javascript",t.id="map_api",t.src="https://maps.googleapis.com/maps/api/js?key="+e,document.body.appendChild(t),e=t=null}setTimeout((function(){try{let e=t.data("dsn-lat"),n=t.data("dsn-len"),i=t.data("dsn-zoom"),a=new google.maps.LatLng(e,n),s=new google.maps.Map(t.get(0),{center:{lat:e,lng:n},mapTypeControl:!1,scrollwheel:!1,draggable:!0,streetViewControl:!1,navigationControl:!1,zoom:i,styles:[{featureType:"water",elementType:"geometry",stylers:[{color:"#e9e9e9"},{lightness:17}]},{featureType:"landscape",elementType:"geometry",stylers:[{color:"#f5f5f5"},{lightness:20}]},{featureType:"road.highway",elementType:"geometry.fill",stylers:[{color:"#ffffff"},{lightness:17}]},{featureType:"road.highway",elementType:"geometry.stroke",stylers:[{color:"#ffffff"},{lightness:29},{weight:.2}]},{featureType:"road.arterial",elementType:"geometry",stylers:[{color:"#ffffff"},{lightness:18}]},{featureType:"road.local",elementType:"geometry",stylers:[{color:"#ffffff"},{lightness:16}]},{featureType:"poi",elementType:"geometry",stylers:[{color:"#f5f5f5"},{lightness:21}]},{featureType:"poi.park",elementType:"geometry",stylers:[{color:"#dedede"},{lightness:21}]},{elementType:"labels.text.stroke",stylers:[{visibility:"on"},{color:"#ffffff"},{lightness:16}]},{elementType:"labels.text.fill",stylers:[{saturation:36},{color:"#333333"},{lightness:40}]},{elementType:"labels.icon",stylers:[{visibility:"off"}]},{featureType:"transit",elementType:"geometry",stylers:[{color:"#f2f2f2"},{lightness:19}]},{featureType:"administrative",elementType:"geometry.fill",stylers:[{color:"#fefefe"},{lightness:20}]},{featureType:"administrative",elementType:"geometry.stroke",stylers:[{color:"#fefefe"},{lightness:17},{weight:1.2}]}]});google.maps.event.addDomListener(window,"resize",(function(){let e=s.getCenter();google.maps.event.trigger(s,"resize"),s.setCenter(e),e=null})),new google.maps.Marker({position:a,animation:google.maps.Animation.BOUNCE,icon:"assets/img/map-marker.png",title:"ASL",map:s}),e=n=i=a=null}catch(e){console.log(e)}}),1e3)}(),await function(){const t=e(".main-slider"),n=e.extend(!0,{speed:1500,grabCursor:!0,allowTouchMove:!0,direction:"horizontal",slidesPerView:1,centeredSlides:!0,slideToClickedSlide:!0,spaceBetween:10,loop:!1,autoplay:!0},dsnGrid.getData(t,"option",{})),i=e(".box-next"),a=e(".box-prev");var s=new TimelineLite;return{isDemoSlide:function(){return t.hasClass("demo-3")},initSlider:function(){let n=t.find(".slide-item"),s=t.find(".dsn-slider-content > .container-header"),o=this,l=[];if(n.each((function(t){const n=e(this),i=n.find(".slide-content"),a=i.find(".title a");n.attr("data-dsn-id",t),i.attr("data-dsn-id",t),0===t&&i.addClass("dsn-active dsn-active-cat"),s.append(i),o.isDemoSlide()||l.push(o.nextSlide(a.text(),i.find(".metas").html(),e(this).find(".image-bg").clone())),dsnGrid.convertTextLine(a)})),!o.isDemoSlide()){l.push(l.shift()),i.find(".swiper-wrapper").append(l);let e=l.pop(),t=l.pop();a.find(".swiper-wrapper").append(t),a.find(".swiper-wrapper").append(e),a.find(".swiper-wrapper").append(l),t=null}l=o=s=n=null},nextSlide:function(e,t,n){return' <div class="swiper-slide">\n                    <div class="d-flex a-item-center h-100">\n                        <div class="content-box-next v-dark-head">\n                            <h3 class="title-next">'+e+'</h3>\n                            <div class="metas">\n'+t+'                            </div>\n                        </div>\n                        <div class="img-box-next p-relative h-100 overflow-hidden">\n'+n.addClass("p-absolute").removeClass("hidden").get(0).outerHTML+'                            <div class="arrow">\n                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1"\n                                     x="0px" y="0px" viewBox="0 0 512 512" xml:space="preserve" class="">\n                            <g>\n                                <g>\n                                    <g>\n                                        <path\n                                                d="M508.875,248.458l-160-160c-4.167-4.167-10.917-4.167-15.083,0c-4.167,4.167-4.167,10.917,0,15.083l141.792,141.792    H10.667C4.771,245.333,0,250.104,0,256s4.771,10.667,10.667,10.667h464.917L333.792,408.458c-4.167,4.167-4.167,10.917,0,15.083    c2.083,2.083,4.813,3.125,7.542,3.125c2.729,0,5.458-1.042,7.542-3.125l160-160C513.042,259.375,513.042,252.625,508.875,248.458z    "\n                                                data-original="#000000" class="active-path" data-old_color="#000000"\n                                                fill="#FFFFFF"/>\n                                    </g>\n                                </g>\n                            </g>\n                        </svg>\n                            </div>\n                        </div>\n                    </div>\n                </div>'},swiperObject:function(i,a=!0){let s={};return this.isDemoSlide()&&(s={768:{slidesPerView:1,spaceBetween:0},575:{slidesPerView:1,spaceBetween:0}}),new Swiper(".main-slider .slide-inner",{speed:n.speed,grabCursor:n.grabCursor,allowTouchMove:n.allowTouchMove,direction:n.direction,slidesPerView:n.slidesPerView,centeredSlides:n.centeredSlides,slideToClickedSlide:n.slideToClickedSlide,loop:n.loop,autoplay:n.autoplay,pagination:{el:t.find(".swiper-pagination"),type:"bullets",clickable:!0},spaceBetween:n.spaceBetween,breakpoints:s,on:{init:function(){this.autoplay.stop(),t.find('[data-dsn="video"] video').each((function(){this.pause()}))},imagesReady:function(){let t=e(this.slides[this.activeIndex]).find('[data-dsn="video"] video');t.length&&t.get(0).play(),t=null}}})},progress:function(e,t=!0){e.on("progress",(function(){let e=this;for(let n=0;n<e.slides.length;n++){let i=e.slides[n].progress,a=.5*(t?e.height:e.width),s=i*a,o=t?"Y":"X";e.slides[n].querySelector(".image-bg").style.transform="translate"+o+"("+s+"px) ",s=o=a=i=null}e=null}))},touchStart:function(t){t.on("touchStart",(function(){e(this.slides).css("transition","")}))},setTransition:function(t){t.on("setTransition",(function(t){e(this.slides).find(".image-bg").css("transition",t-100+"ms  ")}))},slideChange:function(n,i){let a=this;n.on("slideChange",(function(){let i=t.find(".dsn-slider-content .dsn-active"),o=i.data("dsn-id"),l=e(n.slides[n.activeIndex]),r=l.data("dsn-id");if(o===r)return;t.find('[data-dsn="video"] video').each((function(){this.pause()}));let d=e(this.slides[this.activeIndex]).find('[data-dsn="video"] video');d.length&&d.get(0).play();let c=i.find(".dsn-chars-wrapper");i.removeClass("dsn-active-cat");let f=t.find('.dsn-slider-content [data-dsn-id="'+r+'"]'),h=f.find(".dsn-chars-wrapper"),u=o>r;s.progress(1),(s=new TimelineLite).staggerFromTo(u?c.toArray().reverse():c,.3,a.showText().title,a.hideText(u).title,.05,0,(function(){t.find(".dsn-slider-content .slide-content").removeClass("dsn-active").removeClass("dsn-active-cat"),f.addClass("dsn-active"),f.addClass("dsn-active-cat")})),s.staggerFromTo(u?h.toArray().reverse():h,.8,a.hideText(!u).title,a.showText().title,.05,"-=.1"),i=o=l=r=d=c=h=u=null}))},showText:function(){return{title:{autoAlpha:1,x:"0%",scale:1,rotation:0,ease:Back.easeOut.config(4),yoyo:!0},subtitle:{autoAlpha:1,y:"0%",ease:Elastic.easeOut}}},hideText:function(e){return{title:{autoAlpha:0,x:e?"40%":"-40%",rotation:3,ease:Back.easeIn.config(4),yoyo:!0},subtitle:{autoAlpha:0,y:e?"50%":"-50%",ease:Elastic.easeOut}}},run:function(){if(t.length<=0)return;let e="horizontal"===n.direction;this.initSlider();let o=this.swiperObject(this.isDemoSlide(),!e);if(this.isDemoSlide()||(this.progress(o,!e),this.touchStart(o),this.setTransition(o)),this.slideChange(o,!e),this.isDemoSlide()&&!t.hasClass("has-loop")&&o.slideTo(1),i.length<=0||this.isDemoSlide())return window.dsnSwiper.push(o),void(o=null);let l={speed:n.speed,centeredSlides:n.centeredSlides,touchRatio:.2,slideToClickedSlide:n.slideToClickedSlide,direction:n.direction,resistanceRatio:.65,spaceBetween:0,loop:n.loop},r=new Swiper(".box-next",l),d=new Swiper(".box-prev",l);o.controller.control=r,r.controller.control=o,d.controller.control=o,o.controller.control=[d,r],this.progress(r,!e),this.setTransition(r),this.progress(d,!e),this.setTransition(d),i.on("click",(function(){s.isActive()||(r.slides.length===r.activeIndex+1?o.slideTo(0):o.slideNext())})),a.on("click",(function(){s.isActive()||(0===r.activeIndex?o.slideTo(r.slides.length):o.slidePrev())}))}}}().run(),await async function(){const t=e(".dsn-paginate-right-page");if(!t.length)return;t.empty(),e("[data-dsn-title]").each((function(){const n=dsnGrid.getData(this,"title"),i=e(this).offset().top,a=e('<div class="dsn-link-paginate text-transform-upper"></div>');a.html(n),t.append(a),a.on("click",(function(){dsnGrid.scrollTop(i,1,-150)}))}))}(),await function(){let t={delegate:"a:not(.effect-ajax)",type:"image",closeOnContentClick:!1,closeBtnInside:!1,mainClass:"mfp-with-zoom",gallery:{enabled:!0},zoom:{enabled:!0,duration:400,easing:"cubic-bezier(0.36, 0, 0.66, -0.56)",opener:function(e){return e.find("img")}},callbacks:{open:function(){e("html").css({margin:0})}}};e(".gallery-portfolio").each((function(){e(this).magnificPopup(t)})),e(".has-popup .pop-up").length&&(t.delegate="a.pop-up");e(".has-popup").magnificPopup(t)}(),await void e(".gallery-portfolio").each((function(){e(this).justifiedGallery({rowHeight:dsnGrid.getData(this,"rowHeight",250),margins:dsnGrid.getData(this,"margins",15)})})),await function(){class e{constructor(e){this.DOM={el:e},this.DOM.reveal=document.createElement("div"),this.DOM.reveal.className="hover-reveal",this.DOM.reveal.innerHTML=`<div class="hover-reveal__img" style="background-image:url(${this.DOM.el.dataset.img})"></div>`,this.DOM.el.appendChild(this.DOM.reveal),this.DOM.revealImg=this.DOM.reveal.querySelector(".hover-reveal__img"),dsnGrid.convertTextLine(this.DOM.el.querySelectorAll(".work__item-text")),this.DOM.letters=[...this.DOM.el.querySelectorAll(".work__item-text span")],this.initEvents()}initEvents(){this.positionElement=e=>{if($body.hasClass("dsn-ajax-effect"))return;const t=(i=0,a=0,(n=e)||(n=window.event),n.pageX||n.pageY?(i=n.pageX,a=n.pageY):(n.clientX||n.clientY)&&(i=n.clientX+document.body.scrollLeft+document.documentElement.scrollLeft,a=n.clientY+document.body.scrollTop+document.documentElement.scrollTop),{x:i,y:a});var n,i,a;if($effectScroll.isScroller()){const e=$effectScroll.getScrollbar();this.DOM.reveal.style.top=t.y-this.DOM.reveal.offsetHeight/2+e.offset.y+"px",this.DOM.reveal.style.left=t.x-(this.DOM.reveal.offsetHeight/2-60)-e.offset.x+"px"}else{const e={left:document.body.scrollLeft+document.documentElement.scrollLeft,top:document.body.scrollTop+document.documentElement.scrollTop};this.DOM.reveal.style.top=t.y+20-e.top/150+"px",this.DOM.reveal.style.left=t.x+20-e.left+"px"}},this.mouseenterFn=e=>{$body.hasClass("dsn-ajax-effect")||(this.positionElement(e),this.animateLetters(),this.showImage())},this.mousemoveFn=e=>requestAnimationFrame(()=>{$body.hasClass("dsn-ajax-effect")||this.positionElement(e)}),this.mouseleaveFn=()=>{$body.hasClass("dsn-ajax-effect")||this.hideImage()},this.DOM.el.addEventListener("mouseenter",this.mouseenterFn),this.DOM.el.addEventListener("mousemove",this.mousemoveFn),this.DOM.el.addEventListener("mouseleave",this.mouseleaveFn)}showImage(){TweenMax.killTweensOf(this.DOM.revealImg),this.tl=new TimelineMax({onStart:()=>{this.DOM.reveal.style.opacity=1,TweenMax.set(this.DOM.el,{zIndex:1e3})}}).add("begin").set(this.DOM.revealImg,{transformOrigin:"95% 50%",x:"100%"}).add(new TweenMax(this.DOM.revealImg,.2,{ease:Sine.easeOut,startAt:{scaleX:.5,scaleY:1},scaleX:1.5,scaleY:.7}),"begin").add(new TweenMax(this.DOM.revealImg,.8,{ease:Expo.easeOut,startAt:{rotation:10,y:"5%",opacity:0},rotation:0,y:"0%",opacity:1}),"begin").set(this.DOM.revealImg,{transformOrigin:"0% 50%"}).add(new TweenMax(this.DOM.revealImg,.6,{ease:Expo.easeOut,scaleX:1,scaleY:1,opacity:1}),"begin+=0.2").add(new TweenMax(this.DOM.revealImg,.6,{ease:Expo.easeOut,x:"0%"}),"begin+=0.2")}hideImage(){TweenMax.killTweensOf(this.DOM.revealImg),this.tl=new TimelineMax({onStart:()=>{TweenMax.set(this.DOM.el,{zIndex:999})},onComplete:()=>{TweenMax.set(this.DOM.el,{zIndex:""}),TweenMax.set(this.DOM.reveal,{opacity:0})}}).add("begin").add(new TweenMax(this.DOM.revealImg,.2,{ease:Sine.easeOut,opacity:0,x:"-20%"}),"begin")}animateLetters(){TweenMax.killTweensOf(this.DOM.letters),this.DOM.letters.forEach(e=>TweenMax.set(e,{y:0===Math.round(Math.random())?"50%":"0%",opacity:0})),TweenMax.to(this.DOM.letters,1,{ease:Expo.easeOut,y:"0%",opacity:1})}}Array.from(document.querySelectorAll('[data-fx="1"] > .work__item a, a[data-fx="1"]')).forEach(t=>new e(t))}(),await function(){var t=e("#contact-form");if(t<1)return;t.validator(),t.on("submit",(function(n){if(!n.isDefaultPrevented()){return e.ajax({type:"POST",url:"contact.php",data:e(this).serialize(),success:function(e){var n="alert-"+e.type,i=e.message,a='<div class="alert '+n+' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'+i+"</div>";n&&i&&(t.find(".messages").html(a),t[0].reset()),setTimeout((function(){t.find(".messages").html("")}),3e3)},error:function(e){console.log(e)}}),!1}}))}(),await e(".ah-headline").animatedHeadline(),await(e('a[href="#"]').on("click",(function(e){e.preventDefault()})),e('[href*="#"]:not([href="#"])').on("click",(function(t){t.preventDefault();let n=e(e(this).attr("href"));if(!n.length)return n=null,!1;dsnGrid.scrollTop(n.get(0).offsetTop,1,-100),n=null})),void(window.location.hash.length&&($wind.scrollTop(0),dsnGrid.scrollTop(window.location.hash,1,-100)))),await e(".marquee").marquee({duration:dsnGrid.isMobile()?5e3:9e3,gap:30,delayBeforeStart:0,direction:"left",duplicated:!0}),await function(t){t&&e(".tab-section .link-click").off("click");e(".tab-section").each((function(){let t=e(this);t.on("click",".link-click",(function(){e(this).addClass("active").siblings().removeClass("active"),t.find("#"+e(this).attr("id")+"-content").fadeIn(1e3).siblings().hide()}))}))}(),await dsnGrid.dsnAjax({success:()=>{gsap.set("header.p-relative.h-100-v .metas  span",{autoAlpha:0,y:-10}),t(!0).catch(e=>{console.error(e)})},onComplete:()=>{gsap.to("header.p-relative.h-100-v .metas  span",.4,{autoAlpha:1,y:0,stagger:.2})}}).ajaxLoad()}function n(){$wind.on("popstate",(function(n){if(window.location.hash.length)return $wind.scrollTop(0),void dsnGrid.scrollTop(window.location.hash,1,-100);document.location.href.indexOf("#")>-1||setTimeout((function(){var n,i,a;(a=gsap.timeline(),{ajaxLoad:function(){if(!$body.hasClass("dsn-ajax"))return;let t=this;this.ajaxClick.off("click"),this.ajaxClick.on("click",(function(n){n.preventDefault();let i=e(this),s=i.attr("href"),o=i.data("dsn-ajax");s.indexOf("#")>=0||void 0===s?i=s=o=null:t.effectAjax()||(t.effectAjax(!0),e.ajax({url:s,dataType:"html",beforeSend:t.animateAjaxStart.bind(t,o,i),success:function(e){try{history.pushState(null,"",s),a.call(t.animateAjaxEnd.bind(t,e),null,null,"+=0.2")}catch(e){window.location=s}},error:function(e){window.location=s}}))}))},mainRoot:e("main.main-root"),ajaxClick:e("a.effect-ajax "),effectAjax:function(e){if(e)$body.addClass("dsn-ajax-effect");else{if(!1!==e)return $body.hasClass("dsn-ajax-effect");$body.removeClass("dsn-ajax-effect")}},animateAjaxStart:function(e,t){switch(a.clear(),a.addLabel("beforeSend"),dsnGrid.isMobile()&&"next"===e&&(e=void 0),e){case"slider":this.ajaxSlider(t);break;case"work":this.ajaxWork(t);break;case"work-hover":this.ajaxWorkHover(t);break;default:this.ajaxNormal()}$effectScroll.locked(),a.call((function(){dsnGrid.scrollTop(0,.01)}))},ajaxNormal:function(){let t=e('<div class="dsn-ajax-loader dsn-ajax-normal"></div>');$body.append(t),a.to(t,1,{autoAlpha:1,ease:Expo.easeOut},0),t=null},ajaxSlider:function(e){const t=e.parents(".slide-content"),n=t.parents(".main-slider").find(".bg-container .swiper-slide.swiper-slide-active").first(),i=t.find(".title");let a=t.parents(".main-slider").find(".bg-container");n.removeClass("hidden"),this.dsnCreateElement(n,a,i,i)},ajaxWork:function(e){let t=e.parents(".work-item"),i=t.find(".img-next-box"),s=t.find(".sec-title");this.dsnCreateElement(i,i,s,s),a.to(n.find("img"),.5,{height:"100%",top:"0%",y:"0"}),t=i=s=null},ajaxWorkHover:function(e){let t=e,n=t.find(".hover-reveal"),i=t.find(".work__item-text");this.dsnCreateElement(n.find(".hover-reveal__img"),n,i,i),t=n=i=null},addElement:function(e,t,n){if(void 0===t||t.length<=0)return;(void 0===n||n.length<=0)&&(n=t),t.removeClass("line-after").removeClass("line-before");let i=t.clone(),a=n[0].getBoundingClientRect();return void 0===a&&(a={left:0,top:0}),i.css({position:"fix",display:"block",transform:"",transition:"",objectFit:"cover"}),i.css(dsnGrid.getBoundingClientRect(n[0])),i.css(t.dsnGridStyleObject()),e.append(i),i},dsnCreateElement:function(t,s,o,l,r={}){let d=e('<div class="dsn-ajax-loader"></div>');n=this.addElement(d,t,s),(i=this.addElement(d,o,l)).find(".dsn-chars-wrapper").length||dsnGrid.convertTextLine(i),void 0!==r.before&&r.before(d,n,i),$body.append(d),a.to(d,1,{autoAlpha:1,ease:Power4.easeInOut},"-=0.8"),void 0!==r.after&&r.after(d,n,i)},completeElement:function(t){let s=e('[data-dsn-ajax="img"]'),o=e('[data-dsn-ajax="title"]');if(!s.length&&!o.length){let e={value:"0%"};return void a.to(e,1,{value:"100%",onUpdate:function(){t.css("clip-path","inset(0% 0% "+e.value+" 0%)")},onComplete:function(){e=null},ease:Circ.easeIn})}s=s.first();let l={top:0,left:0,width:"100%",height:"100%",transform:"none"};if(i.length){o=o.first(),o.find(".dsn-chars-wrapper").length||dsnGrid.convertTextLine(o),l=o.offset(),void 0===l&&(l={top:0,left:0}),a.set(i.find(".dsn-chars-wrapper"),{x:i.offset().left-l.left,y:i.offset().top-l.top},"-=1");let e=i.find(".dsn-chars-wrapper").toArray();i.offset().left<l.left&&e.reverse(),a.set(i,{top:l.top,left:l.left},"-=0.8"),a.to(i,.4,{padding:"0",borderWidth:0,yoyo:!0}),a.to(i,.8,{css:o.dsnGridStyleObject(),yoyo:!0},"-=0.8"),i.css("width",o.outerWidth()),a.set(e,{color:i.css("color")}),a.staggerTo(e,.8,{y:"0",x:"0",ease:Back.easeOut.config(1),color:o.css("color"),yoyo:!0},.02,"-=0.35")}s.length&&(l={top:s.get(0).offsetTop,left:s.get(0).offsetLeft,width:s.width(),height:s.height()}),n.length&&a.to(n,{duration:1,top:l.top,left:l.left,width:l.width,height:l.height,objectFit:"cover",borderRadius:0,ease:Power3.easeInOut()},"-=1.4");let r={value:"0%"};a.to(r,.5,{value:"100%",onUpdate:function(){t.css("clip-path","inset(0% 0% "+r.value+" 0%)")},onComplete:function(){r=null},ease:Circ.easeIn})},animateAjaxEnd:function(n){a.call(function(){dsnGrid.initAjax(n),this.mainRoot.html(e(n).filter("main.main-root").html()),t(!0).catch(e=>{console.error(e)})}.bind(this),null,"+=1");let i=e(".dsn-ajax-loader");i.hasClass("dsn-ajax-normal")?a.to(i,1,{autoAlpha:0,ease:Expo.easeIn}):a.call(this.completeElement.bind(this,i)),a.eventCallback("onComplete",function(){i.remove(),this.effectAjax(!1)}.bind(this))},backAnimate:function(t){if(!t)return;let n=this;e.ajax({url:t,dataType:"html",beforeSend:n.animateAjaxStart.bind(n),success:function(e){a.call(n.animateAjaxEnd.bind(n,e),null,null,"+=0.2")},error:function(e){window.location=t}})}}).backAnimate(document.location)}),100)}))}function i(t){setTimeout((function(){e("[data-dsn-"+t+"]").each((function(){"bg"===t?e(this).css("background-image",`url(${dsnGrid.getData(this,t,"")})`):e(this).attr(t,dsnGrid.getData(this,t,""))}))}),100)}async function a(t){const n=e(".cursor");if(!dsnGrid.isMobile()&&$body.hasClass("dsn-cursor-effect")){if(!0===t)return n.attr("class","cursor"),void i();dsnGrid.mouseMove(n,{speed:.5}),i()}else n.length&&(n.css("display","none"),$body.removeClass("dsn-cursor-effect"));function i(){dsnGrid.elementHover(n,"a:not(> img):not(.vid) , .dsn-button-sidebar,  button , .mfp-container","cursor-scale-full"),dsnGrid.elementHover(n,".c-hidden , .social-side a","no-scale"),dsnGrid.elementHover(n,".has-popup a , .work-item-box a:not(.effect-ajax)","cursor-scale-half cursor-open"),dsnGrid.elementHover(n,'[data-cursor="close"]',"cursor-scale-full cursor-close"),dsnGrid.elementHover(n,"a.link-pop ","cursor-scale-full cursor-view")}}!function(){let i=e(".preloader"),a=i.find(".percent"),s=i.find(".title .text-fill"),o={value:0},l=i.find(".preloader-bar"),r=l.find(".preloader-progress"),d=dsnGrid.pageLoad(0,100,1e3,(function(e){a.text(e),o.value=e,s.css("clip-path","inset("+(100-e)+"% 0% 0% 0%)"),r.css("width",e+"%")}));i.length||(n(),t().catch(e=>{console.log(e)}));$wind.on("load",(function(){clearInterval(d),gsap.timeline().to(o,1,{value:100,onUpdate:function(){a.text(o.value.toFixed(0)),s.css("clip-path","inset("+(100-o.value)+"% 0% 0% 0%)"),r.css("width",o.value+"%")}}).to(i.find("> *:not(.preloader-bar)"),{y:-30,autoAlpha:0}).call((function(){i.length&&(n(),t().catch(e=>{console.log(e)}))})).set(o,{value:0}).to(o,.8,{value:100,onUpdate:function(){i.css("clip-path","inset(0% 0%"+o.value+"%   0%)")},ease:Power2.easeInOut},"+=0.5").call((function(){i.remove(),d=i=a=s=o=l=r=null}))}))}(),a(),window.$effectScroll=function(){const t=window.Scrollbar;var n=document.querySelector("#dsn-scrollbar");return{start:function(){$body.removeClass("locked-scroll"),e(".box-view-item .box-img .dsn-scroll-box").each((function(){t.init(this,{damping:.06})})),this.isScroller(!0)&&(t.init(n,{damping:.06,renderByPixels:!0,continuousScrolling:!1,plugins:{overscroll:!0}}),this.contactForm())},contactForm:function(){const n=e(".contact-modal .contact-container");n.length&&t.init(n.get(0),{damping:.06})},isScroller:function(e){e&&(n=document.querySelector("#dsn-scrollbar"));let t=!$body.hasClass("dsn-effect-scroll")||dsnGrid.isMobile()||null===n;return t&&e&&$body.addClass("dsn-mobile"),!t},locked:function(){if($body.addClass("locked-scroll"),this.isScroller()){let e=this.getScrollbar();void 0!==e&&e.destroy(),e=null}},getScrollbar:function(e){return void 0===e?t.get(n):t.get(document.querySelector(e))},getListener:function(e,t=!0){if(void 0===e)return;let n=this;n.isScroller()?n.getScrollbar().addListener(e):t&&$wind.on("scroll",e),n=null},scrollNavigate:function(){let t=e(".wrapper").offset();t=t?t.top:0,e(".scroll-top , .scroll-to-top").on("click",(function(){dsnGrid.scrollTop(0,2)})),e(".scroll-d").on("click",(function(){dsnGrid.scrollTop(t,2,-1*e(".scrollmagic-pin-spacer").height()-200||-200)}))}}}()}(jQuery);